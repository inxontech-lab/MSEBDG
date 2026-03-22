using Domain.Core;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Shared.CampsClient.Master;
using Shared.CampsClient.Transactions;
using Radzen;
using Radzen.Blazor;

namespace MSEBDGCP.Components.Pages.Camps
{
    public partial class CampDetails
    {
        [Inject] DialogService DialogService { get; set; }
        [Inject] NotificationService NotificationService { get; set; }
        [Inject] protected CampDetailsService? CampDetailsService { get; set; }
        [Inject] protected CampTypeService? CampTypeService { get; set; }
        [Inject] protected CountryService? CountryService { get; set; }
        [Inject] protected SeCommitteeService? SeCommitteeService { get; set; }

        private CampTypeListRespDTO _CampTypeListRespDTO = new();
        public List<CampType>? CampTypeList { get; set; } = new();
        private CountryListRespDTO _CountryListRespDTO = new();
        public List<CountryMst>? CountryList { get; set; } = new();
        private SECommitteeRespDTO _SECommitteeRespDTO = new();
        public List<ShahEmdadiaCommittee>? SECommitteeList { get; set; } = new();

        public CampDetail CampDetail { get; set; } = new();
        bool activeFlag = true;
        RadzenDataGrid<CampDetailsDTO> CampDetailsDTO;
        public List<CampDetailsDTO>? CampDetailsList { get; set; }
        private CampDetailsReqDTO _CampDetailsReqDTO;
        private CampDetailsRespDTO CampDetailsRespDTO;

        protected override async Task OnInitializedAsync()
        {
            await GetCampTypeList();
            await GetCountryList();
            await GetCountryList();
            await GetSeCommitteeList();
            await GetCampDetails();
        }

        private async Task GetCampDetails()
        {
            _CampDetailsReqDTO = new();
            try
            {
                var result =await CampDetailsService?.GetAllCampDetailsList();

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    CampDetailsList = result.CampDetailsList;
                }
            }
            catch (Exception ex)
            {
                CampDetailsList = null;
            }
        }

        public async Task OpenRecord(int CampId)
        {
            CampDetailsDTO CampDetailsDTO = new();
            CampDetailsDTO = CampDetailsList?.Where(x => x.Id == CampId).FirstOrDefault();
            if (CampDetailsDTO != null)
            {
                CampDetail.Id = CampDetailsDTO.Id;
                CampDetail.CampNameEn = CampDetailsDTO.CampNameEn??"";
                CampDetail.CampNameBn = CampDetailsDTO.CampNameBn ?? "";
                CampDetail.CampTypeId = CampDetailsDTO.CampTypeId ?? 0;
                CampDetail.Country = CampDetailsDTO.CountryId ?? 0;
                CampDetail.SecommitteeId = CampDetailsDTO.SECommitteeId;
                CampDetail.UnitCommitteeId = CampDetailsDTO.UnitCommitteeId;
                CampDetail.CampDate = CampDetailsDTO.CampDate ?? DateTime.Today;
                CampDetail.CampLocationBn = CampDetailsDTO.CampLocationBn;
                CampDetail.Coordinator = CampDetailsDTO.Coordinator;
                if (CampDetailsDTO.Active == 1)
                {
                    activeFlag = true;
                }
                else
                {
                    activeFlag = false;
                }
            }
        }

        private void ClearForm()
        {
            CampDetail = new();
        }

        private async Task SaveCamp(CampDetail CampDetail)
        {
            bool? confirmed = await DialogService.Confirm(
                 "Are you sure to save camp details?",
                 "Confirm save",
                 new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" }
             );

            if (confirmed == true)
            {
                CampDetailsRespDTO = new();
                if (activeFlag)
                {
                    CampDetail.Active = 1;
                }
                else
                {
                    CampDetail.Active = 0;
                }

                if (CampDetail.Id > 0)
                {
                    CampDetailsRespDTO = await CampDetailsService.UpdateCampDetailsAsync(CampDetail);
                }
                else
                {
                    CampDetailsRespDTO = await CampDetailsService.SaveCampDetailsAsync(CampDetail);
                }

                

                if (CampDetailsRespDTO != null)
                {
                    if (CampDetailsRespDTO.RESPONSE_CODE != null)
                    {
                        if (CampDetailsRespDTO.RESPONSE_CODE.Equals(ConfigClass.SUCCESS))
                        {
                            ClearForm();
                            NotificationService.Notify(NotificationSeverity.Success, "Saved", "Camp details saved");
                            CampDetailsList = CampDetailsRespDTO.CampDetailsList;
                            await CampDetailsDTO.RefreshDataAsync();
                        }
                        else
                        {
                            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Camp details not saved" });
                        }
                    }
                    else
                    {
                        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Camp details not saved" });
                    }
                }
                else
                {
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Camp details not saved" });
                }
            }
        }

        private async Task GetSeCommitteeList()
        {
            _SECommitteeRespDTO = new();
            try
            {
                var result = await SeCommitteeService?.GetSeCommitteeList();

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    SECommitteeList = result.SECommitteeList;
                }
            }
            catch (Exception ex)
            {
                SECommitteeList = null;
            }
        }

        private async Task GetCampTypeList()
        {
            _CampTypeListRespDTO = new();
            try
            {
                var result = await CampTypeService?.GetCampTypeList();

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    CampTypeList = result.CampTypeList;
                }
            }
            catch (Exception ex)
            {
                CampTypeList = null;
            }
        }
        
        private async Task GetCountryList()
        {
            _CountryListRespDTO = new();
            try
            {
                var result = await CountryService?.GetCountryList();

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    CountryList = result.CountryList;
                }
            }
            catch (Exception ex)
            {
                CountryList = null;
            }
        }
    }
}
