using Domain.Core;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Shared.CampsClient.CommonForms;
using Shared.CampsClient.Master;
using Shared.CampsClient.Transactions;
using Newtonsoft.Json.Linq;
using Radzen;
using System.Globalization;
using Shared;

namespace MSEBDGCP.Components.Pages.Camps
{
    public partial class GrpReg
    {
        [Inject] DialogService DialogService { get; set; }
        [Inject] NotificationService NotificationService { get; set; }
        [Inject] BeneficiaryService BeneficiaryService { get; set; }
        [Inject] protected AddressService? AddressService { get; set; }
        [Inject] protected BloodGroupService? BloodGroupService { get; set; }
        [Inject] protected FemaleQuestionService? FemaleQuestionService { get; set; }
        [Inject] protected GenderService? GenderService { get; set; }
        [Inject] protected QuestionMasterService? QuestionMasterService { get; set; }
        [Inject] protected GneralHealthQuestionService? GneralHealthQuestionService { get; set; }
        [Inject] protected MedicalConditionService? MedicalConditionService { get; set; }
        [Inject] protected RiskFactorService? RiskFactorService { get; set; }
        [Inject] protected CampDetailsService? CampDetailsService { get; set; }

        [Inject] public IConfiguration _configuration { get; set; }

        private CampDetailsReqDTO _CampDetailsReqDTO;
        private BanglaDate BanglaDate = new();
        public List<CampDetailsDTO>? _CampDetailsList { get; set; } = new();
        public List<Gender>? _GenderList { get; set; } = new();
        public List<Division>? _DivisionList { get; set; } = new();
        public List<District>? _DistrictList { get; set; } = new();
        public List<Upazila>? _UpazilaList { get; set; } = new();
        public List<Union>? _UnionList { get; set; } = new();
        private List<BloodGroup> bloodGroupList { get; set; } = new();
        private List<YesNoValue> _YesNoAnsValue { get; set; } = new();
        private List<QuestionCategory> QuestionCategoryList { get; set; } = new();
        private List<QuestionMaster> QuestionList = new();
        public BeneficiaryDetailsReqDTO ReqDTO { get; set; } = new();

        void OnAnswerChanged(int questionId, object? value)
        {
           
        }
        public void GetAge(DateTime? dateOfBirth)
        {
            if (dateOfBirth != null)
            {
                var today = DateTime.Today;
                int age = today.Year - dateOfBirth.Value.Year;

                if (dateOfBirth.Value.Date > today.AddYears(-age))
                    age--;

                ReqDTO.Beneficiary.Age = age.ToString();
            }
        }

        private async Task UpdateBloodGroup()
        {
            var result = await DialogService.OpenAsync<BloodGroupUpdate>(
            "Update Blood Group",
            new Dictionary<string, object>() { },
            new DialogOptions() { });
        }

        private void OnCampChange(object value)
        {
            var camp = _CampDetailsList?.FirstOrDefault(c => c.Id == (int)value);
            if (camp != null)
            {
                campLocation = "স্থান: " + camp.CampLocationBn ?? camp.CampLocationEn;
                CampDate = "তারিখ: " + BanglaDate.ToBanglaDate(camp.CampDate);
            }
            else
            {
                campLocation = "";
                CampDate = "";
            }
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            GetCampDetails();
            await GetGenderList();
            await GetDivisionList();
            await GetBloodGroupList();
            await GetQuestionList();
            QuestionCategoryList = new List<QuestionCategory>
            {
                new QuestionCategory { CategoryId = 1, CategoryName = "General Health" },
                new QuestionCategory { CategoryId = 2, CategoryName = "Medical Condition" },
                new QuestionCategory { CategoryId = 3, CategoryName = "Medication" },
                new QuestionCategory { CategoryId = 4, CategoryName = "Risk Factor" },
                new QuestionCategory { CategoryId = 5, CategoryName = "Question for Female" }
            };
        }

        private async Task GetBloodGroupList()
        {
            try
            {
                BloodGroupListRespDTO resp = await BloodGroupService.GetBloodGroupList();
                if (resp != null)
                {
                    if (resp.BloodGroupList != null)
                    {
                        bloodGroupList = resp.BloodGroupList;
                    }
                }
            }
            catch (Exception ex)
            {
                bloodGroupList = null;
            }
        }

        private async Task GetQuestionList()
        {
            try
            {
                QuestionList = await QuestionMasterService.GetQuestionList();
                QuestionAnsModelCreate();
            }
            catch (Exception ex)
            {
                QuestionList = null;
            }
        }

        private async Task GetDistrict(object value)
        {
            try
            {
                var result = await AddressService?.GetDistrictList(Convert.ToInt32(value));

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    _DistrictList = result.DistrictList;
                }
            }
            catch (Exception ex)
            {
                _DistrictList = null;
            }
        }

        private async Task GetUpazila(object value)
        {
            try
            {
                var result = await AddressService?.GetUpazilaList(Convert.ToInt32(value));

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    _UpazilaList = result.UpazilaList;
                }
            }
            catch (Exception ex)
            {
                _UpazilaList = null;
            }
        }

        private async Task GetWardUnion(object value)
        {
            try
            {
                var result = await AddressService?.GetWardUnionList(Convert.ToInt32(value));

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    _UnionList = result.UnionList;
                }
            }
            catch (Exception ex)
            {
                _UnionList = null;
            }
        }

        private void GetCampDetails()
        {
            _CampDetailsReqDTO = new();
            if (_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value.Equals("0"))
            {
                _CampDetailsReqDTO.campDateString = DateTime.Now.ToString("dd-MM-yyyy");
            }
            
            try
            {
                var result = CampDetailsService?.GetCampDetailsList(_CampDetailsReqDTO).Result;

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    _CampDetailsList = result.CampDetailsList;
                }
            }
            catch (Exception ex)
            {
                _CampDetailsList = null;
            }
        }

        private async Task GetDivisionList()
        {
            try
            {
                var result = await AddressService?.GetDivisionList();

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    _DivisionList = result.DivisionList;
                }
            }
            catch (Exception ex)
            {
                _DivisionList = null;
            }
        }

        private async Task GetGenderList()
        {
            try
            {
                var result = await GenderService?.GetGenderList();

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    _GenderList = result.GenderList;
                }
            }
            catch (Exception ex)
            {
                _GenderList = null;
            }
        }

        private async Task SaveBeneficiary(BeneficiaryDetailsReqDTO data)
        {
            bool? confirmed = await DialogService.Confirm(
                 "Are you sure to save benificiery details?",
                 "Confirm save",
                 new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" }
             );

            if (confirmed == true)
            {
                var result = await BeneficiaryService.SaveBeneficiaryDetailsAsync(data);
               
                if (result != null)
                {
                    if (result.RESPONSE_CODE != null)
                    {
                        if (result.RESPONSE_CODE.Equals(ConfigClass.SUCCESS))
                        {
                            ClearForm();
                            NotificationService.Notify(NotificationSeverity.Success, "Saved", "Beneficiery details saved");
                        }
                        else
                        {
                            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Beneficiery details not saved" });
                        }
                    }
                    else
                    {
                        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Beneficiery details not saved" });
                    }
                }
                else
                {
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Beneficiery details not saved" });
                }
            }
        }

        private void ClearForm()
        {
            ReqDTO.Beneficiary.MobileNumber = null;
            ReqDTO.Beneficiary.FullName = "";
            ReqDTO.Beneficiary.FatherName = null;
            ReqDTO.Beneficiary.MotherName = null;
            ReqDTO.Beneficiary.GenderId = null;
            ReqDTO.Beneficiary.DateOfBirth = null;
            ReqDTO.Beneficiary.Age = null;
            ReqDTO.Beneficiary.BloodGroup = null;
            ReqDTO.Beneficiary.NationalId = null;
            ReqDTO.Beneficiary.HeightFeet = null;
            ReqDTO.Beneficiary.HeightInch = null;
            ReqDTO.Beneficiary.HeightInCm = null;
            ReqDTO.Beneficiary.Weight = null;
            ReqDTO.Beneficiary.Bmi = null;
            ReqDTO.Beneficiary.TimesDonated = null;
            ReqDTO.Beneficiary.Education = null;
            ReqDTO.Beneficiary.DivisionId = null;
            ReqDTO.Beneficiary.DistrictId = null;
            ReqDTO.Beneficiary.UpazilaId = null;
            ReqDTO.Beneficiary.WardUnionId = null;
            ReqDTO.Beneficiary.Address = null;
            ReqDTO.Beneficiary.Mobile = null;
            ReqDTO.Beneficiary.Active = null;
            ReqDTO.Beneficiary.CreatebBy = null;
            ReqDTO.Beneficiary.CreatedDate = null;

            QuestionAnsModelCreate();
        }

        private void QuestionAnsModelCreate()
        {
            ReqDTO.BeneficiaryQuestionAnswers = QuestionList.Select(q => new BeneficiaryQuestionAnswer
            {
                // BeneficiaryId = BeneficiaryId,
                QuestionId = q.QuestionId,
                AnswerText = "",
                AnswerYesNo = 0,
                AnswerOptionId = 0
            }).ToList();
        }
    }

    public class YesNoValue
    {
        public int QuestionId { get; set; }
        public int AnswerValue { get; set; }
    }
}
