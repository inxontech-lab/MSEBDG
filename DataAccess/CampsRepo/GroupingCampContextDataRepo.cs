using Domain.Core;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.CampsRepo
{
    public class GroupingCampContextDataRepo : IGroupingCampContextDataRepo
    {
        private MsebdgcampsContext _MsebdgcampsContext;
        private CountryListRespDTO _CountryListResp;
        private SECommitteeRespDTO _SECommitteeRespDTO;
        private GenderListRespDTO _GenderListRespDTO;
        private BloodGroupListRespDTO _BloodGroupListRespDTO;
        private CampTypeListRespDTO _CampTypeListRespDTO;
        private DivisionListRespDTO _DivisionListRespDTO;
        private DistrictListRespDTO _DistrictListRespDTO;
        private UpazilaListRespDTO _UpazilaListRespDTO;
        private UnionWardListRespDTO _UnionWardListRespDTO;
        private CampDetailsRespDTO _CampDetailsRespDTO;
        private GeneralHealthQuestionRespDTO _GeneralHealthQuestionRespDTO;
        private MedicalConsitonListRespDTO _MedicalConsitonListRespDTO;
        private RiskFactorQuestRespDTO _RiskFactorQuestRespDTO;
        private FemaleQuestionsRespDTO _FemaleQuestionsRespDTO;
        private CommonRespDTO _CommonRespDTO;
        private BeneficiaryInfoRespDTO _BeneficiaryInfoRespDTO;

        public GroupingCampContextDataRepo(MsebdgcampsContext MsebdgcampsContext)
        {
            _MsebdgcampsContext = MsebdgcampsContext;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<BeneficiaryInfoRespDTO> GetBeneficiaryByMobile(string MobileNumber)
        {
            _BeneficiaryInfoRespDTO = new();
            try
            {
                var Beneficiary = await _MsebdgcampsContext.Beneficiaries.Where(b => b.MobileNumber == MobileNumber).FirstOrDefaultAsync();
                if (Beneficiary != null)
                {
                    _BeneficiaryInfoRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _BeneficiaryInfoRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _BeneficiaryInfoRespDTO.Beneficiary = Beneficiary;
                }
                else
                {
                    _BeneficiaryInfoRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _BeneficiaryInfoRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _BeneficiaryInfoRespDTO.Beneficiary = null;
                }
            }
            catch (Exception ex) {
                _BeneficiaryInfoRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _BeneficiaryInfoRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _BeneficiaryInfoRespDTO.Beneficiary = null;
            }
            return _BeneficiaryInfoRespDTO;
        }

        public async Task<CommonRespDTO> UpdateBloodGroupByMobile(int BloodGroup, string MobileNumber)
        {
            try
            {
                _CommonRespDTO = new();
                if (BloodGroup > 0)
                {
                    var beneficiary = await _MsebdgcampsContext.Beneficiaries.FirstOrDefaultAsync(b => b.MobileNumber == MobileNumber);
                    if (beneficiary != null)
                    {
                        beneficiary.BloodGroup = BloodGroup;
                        await _MsebdgcampsContext.SaveChangesAsync();
                    }
                    _CommonRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _CommonRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                }
                else
                {
                    _CommonRespDTO.RESPONSE_CODE = ConfigClass.INVALID_REQUEST;
                    _CommonRespDTO.RESPONSE_DESCRPTION = ConfigClass.INVALID_REQUEST_MESSAGE;
                }
            }
            catch(Exception ex) 
            {
                _CommonRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CommonRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
            }
            return _CommonRespDTO;
        }

        public async Task<CommonRespDTO> SaveBeneficiaryDetailsAsync(BeneficiaryDetailsReqDTO reqDTO)
        {
            _CommonRespDTO = new();
            try
            {
                var beneficiary = reqDTO.Beneficiary;
                _MsebdgcampsContext.Beneficiaries.Add(beneficiary);
                await _MsebdgcampsContext.SaveChangesAsync();
                var beneficiaryId = beneficiary.Id;

                foreach (var ans in reqDTO.BeneficiaryQuestionAnswers)
                {
                    ans.BeneficiaryId = beneficiaryId;
                    ans.CreatedAt = DateTime.Now;
                }

                _MsebdgcampsContext.BeneficiaryQuestionAnswers.AddRange(reqDTO.BeneficiaryQuestionAnswers);
                await _MsebdgcampsContext.SaveChangesAsync();
                
                _CommonRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                _CommonRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
            }
            catch(Exception ex)
            {
                _CommonRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CommonRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
            }
            return _CommonRespDTO;
        }

        public List<QuestionMaster> GetQuestionList()
        {
            List<QuestionMaster> lstQuestions = new();
            try
            {
                lstQuestions = _MsebdgcampsContext.QuestionMasters
                        .Where(q => q.IsActive)
                        .ToList();
            }
            catch (Exception ex)
            {
                lstQuestions = new();
            }
            return lstQuestions;
        }

        public FemaleQuestionsRespDTO GetFemaleDonorQuestions()
        {
            _FemaleQuestionsRespDTO = new();
            try
            {
                var femaleQuestions = _MsebdgcampsContext.FemaleDonorQuestions.Where(x => x.IsActive == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (femaleQuestions != null)
                {
                    _FemaleQuestionsRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _FemaleQuestionsRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _FemaleQuestionsRespDTO.FemaleDonorQuestionList = femaleQuestions;
                }
                else
                {
                    _FemaleQuestionsRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _FemaleQuestionsRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _FemaleQuestionsRespDTO.FemaleDonorQuestionList = null;
                }
            }
            catch (Exception ex)
            {
                _FemaleQuestionsRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _FemaleQuestionsRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _FemaleQuestionsRespDTO.FemaleDonorQuestionList = null;
            }
            return _FemaleQuestionsRespDTO;
        }

        public RiskFactorQuestRespDTO GetRiskFactQuestions()
        {
            _RiskFactorQuestRespDTO = new();
            try
            {
                var riskFactors = _MsebdgcampsContext.RiskFactorQuestions.Where(x => x.IsActive == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (riskFactors != null)
                {
                    _RiskFactorQuestRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _RiskFactorQuestRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _RiskFactorQuestRespDTO.RiskFactorQuestionList = riskFactors;
                }
                else
                {
                    _RiskFactorQuestRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _RiskFactorQuestRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _RiskFactorQuestRespDTO.RiskFactorQuestionList = null;
                }
            }
            catch (Exception ex)
            {
                _RiskFactorQuestRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _RiskFactorQuestRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _RiskFactorQuestRespDTO.RiskFactorQuestionList = null;
            }
            return _RiskFactorQuestRespDTO;
        }

        public MedicalConsitonListRespDTO GetMedicalConditonList()
        {
            _MedicalConsitonListRespDTO = new();
            try
            {
                var conditions = _MsebdgcampsContext.MedicalConditions.Where(x => x.IsActive == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (conditions != null)
                {
                    _MedicalConsitonListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _MedicalConsitonListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _MedicalConsitonListRespDTO.MedicalConditionList = conditions;
                }
                else
                {
                    _MedicalConsitonListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _MedicalConsitonListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _MedicalConsitonListRespDTO.MedicalConditionList = null;
                }
            }
            catch (Exception ex)
            {
                _MedicalConsitonListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _MedicalConsitonListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _MedicalConsitonListRespDTO.MedicalConditionList = null;
            }
            return _MedicalConsitonListRespDTO;
        }

        public GeneralHealthQuestionRespDTO GetGeneralHealtQuestions()
        {
            _GeneralHealthQuestionRespDTO = new();
            try
            {
                var questions = _MsebdgcampsContext.GeneralHealthQuestions.Where(x => x.IsActive == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (questions != null)
                {
                    _GeneralHealthQuestionRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _GeneralHealthQuestionRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _GeneralHealthQuestionRespDTO.GeneralHealthQuestionList = questions;
                }
                else
                {
                    _GeneralHealthQuestionRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _GeneralHealthQuestionRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _GeneralHealthQuestionRespDTO.GeneralHealthQuestionList = null;
                }
            }
            catch (Exception ex)
            {
                _GeneralHealthQuestionRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _GeneralHealthQuestionRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _GeneralHealthQuestionRespDTO.GeneralHealthQuestionList = null;
            }
            return _GeneralHealthQuestionRespDTO;
        }

        public async Task<CampDetailsRespDTO> GetCampDetailsList(int? campId, int? campTypeId, int? seCommitteeId, int? unitCommitteeId, string? campDateString)
        {
            _CampDetailsRespDTO = new();
            try
            {
                DateTime? campDate = null;

                if (!string.IsNullOrWhiteSpace(campDateString))
                {
                    // Expected: dd-MM-yyyy
                    if (DateTime.TryParseExact(campDateString, "dd-MM-yyyy",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out DateTime parsedDate))
                    {
                        campDate = parsedDate.Date;
                    }
                }

                var query = (from c in _MsebdgcampsContext.CampDetails

                                       // LEFT JOIN CampType
                                   join ct in _MsebdgcampsContext.CampTypes
                                       on c.CampTypeId equals ct.Id into ctGroup
                                   from ct in ctGroup.DefaultIfEmpty()

                                       // LEFT JOIN Country
                                   join co in _MsebdgcampsContext.CountryMsts
                                       on c.Country equals co.CountryId into coGroup
                                   from co in coGroup.DefaultIfEmpty()

                                       // LEFT JOIN ShahEmdadiaCommittee (nullable)
                                   join se in _MsebdgcampsContext.ShahEmdadiaCommittees
                                       on c.SecommitteeId equals se.Id into seGroup
                                   from se in seGroup.DefaultIfEmpty()

                                       // LEFT JOIN UnitCommittee (nullable)
                                   join uc in _MsebdgcampsContext.UnitCommittees
                                       on c.UnitCommitteeId equals uc.Id into ucGroup
                                   from uc in ucGroup.DefaultIfEmpty()

                                   select new CampDetailsDTO
                                   {
                                       Id = c.Id,
                                       CampNameEn = c.CampNameEn,
                                       CampNameBn = c.CampNameBn,
                                       CampTypeId = c.CampTypeId,
                                       CampTypeName = ct.CampTypeName,
                                       CountryId = c.Country,
                                       CountryName = co.CountryName,
                                       SECommitteeId = c.SecommitteeId,
                                       SECommitteeNameEn = se.SecommitteeNameEn,
                                       SECommitteeNameBn = se.SecommitteeNameBn,
                                       UnitCommitteeId = c.UnitCommitteeId,
                                       UnitCommitteeNameEn = uc.UnitCommitteeNameEn,
                                       UnitCommitteeNameBn = uc.UnitCommitteeNameBn,
                                       CampDate = c.CampDate,
                                       CampLocationEn = c.CampLocationEn,
                                       CampLocationBn = c.CampLocationBn,
                                       Lattitude = c.Lattitude,
                                       Longitude = c.Longitude,
                                       Coordinator = c.Coordinator,
                                       Phone1 = c.Phone1,
                                       Phone2 = c.Phone2,
                                       Active = c.Active
                                   }); //.Where(x => x.Active == 1).ToListAsync().OrderByDescending(x => x.CampDate).ToListAsync();

                                    if (campId.HasValue && campId > 0)
                                        query = query.Where(x => x.Id == campId);
                                    if (campTypeId.HasValue && campTypeId > 0)
                                        query = query.Where(x => x.CampTypeId == campTypeId);
                                    if (seCommitteeId.HasValue && seCommitteeId > 0)
                                        query = query.Where(x => x.SECommitteeId == seCommitteeId);
                                    if (unitCommitteeId.HasValue && unitCommitteeId > 0)
                                        query = query.Where(x => x.UnitCommitteeId == unitCommitteeId);

                                    if (campDate.HasValue)
                                    {
                                        query = query.Where(x => x.CampDate == campDate);
                                    }
                                    else
                                    {
                                        query = query.Where(x => x.CampDate <= DateTime.Now);
                                    }

                query = query.Where(x => x.Active == 1)
                                 .OrderBy(x => x.CampDate);

                var camps = await query.ToListAsync();

                if (camps != null)
                {
                    _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _CampDetailsRespDTO.CampDetailsList = camps;
                }
                else
                {
                    _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _CampDetailsRespDTO.CampDetailsList = null;
                }
            }
            catch (Exception ex)
            {
                _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE+"-"+ ex.ToString();
                _CampDetailsRespDTO.CampDetailsList = null;
            }
            return _CampDetailsRespDTO;
        }

         public async Task<CampDetailsRespDTO> GetAllCampDetailsList()
        {
            _CampDetailsRespDTO = new();
            try
            {
                var query = (from c in _MsebdgcampsContext.CampDetails

                                       // LEFT JOIN CampType
                                   join ct in _MsebdgcampsContext.CampTypes
                                       on c.CampTypeId equals ct.Id into ctGroup
                                   from ct in ctGroup.DefaultIfEmpty()

                                       // LEFT JOIN Country
                                   join co in _MsebdgcampsContext.CountryMsts
                                       on c.Country equals co.CountryId into coGroup
                                   from co in coGroup.DefaultIfEmpty()

                                       // LEFT JOIN ShahEmdadiaCommittee (nullable)
                                   join se in _MsebdgcampsContext.ShahEmdadiaCommittees
                                       on c.SecommitteeId equals se.Id into seGroup
                                   from se in seGroup.DefaultIfEmpty()

                                       // LEFT JOIN UnitCommittee (nullable)
                                   join uc in _MsebdgcampsContext.UnitCommittees
                                       on c.UnitCommitteeId equals uc.Id into ucGroup
                                   from uc in ucGroup.DefaultIfEmpty()

                                   select new CampDetailsDTO
                                   {
                                       Id = c.Id,
                                       CampNameEn = c.CampNameEn,
                                       CampNameBn = c.CampNameBn,
                                       CampTypeId = c.CampTypeId,
                                       CampTypeName = ct.CampTypeName,
                                       CountryId = c.Country,
                                       CountryName = co.CountryName,
                                       SECommitteeId = c.SecommitteeId,
                                       SECommitteeNameEn = se.SecommitteeNameEn,
                                       SECommitteeNameBn = se.SecommitteeNameBn,
                                       UnitCommitteeId = c.UnitCommitteeId,
                                       UnitCommitteeNameEn = uc.UnitCommitteeNameEn,
                                       UnitCommitteeNameBn = uc.UnitCommitteeNameBn,
                                       CampDate = c.CampDate,
                                       CampLocationEn = c.CampLocationEn,
                                       CampLocationBn = c.CampLocationBn,
                                       Lattitude = c.Lattitude,
                                       Longitude = c.Longitude,
                                       Coordinator = c.Coordinator,
                                       Phone1 = c.Phone1,
                                       Phone2 = c.Phone2,
                                       Active = c.Active
                                   }); //.Where(x => x.Active == 1).ToListAsync().OrderByDescending(x => x.CampDate).ToListAsync();

                query = query.OrderByDescending(x => x.CampDate);

                var camps = await query.ToListAsync();

                if (camps != null)
                {
                    _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _CampDetailsRespDTO.CampDetailsList = camps;
                }
                else
                {
                    _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _CampDetailsRespDTO.CampDetailsList = null;
                }
            }
            catch (Exception ex)
            {
                _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE+"-"+ ex.ToString();
                _CampDetailsRespDTO.CampDetailsList = null;
            }
            return _CampDetailsRespDTO;
        }

        public async Task<CampDetailsRespDTO> SaveCampDetailsAsync(CampDetail camp)
        {
            _CampDetailsRespDTO = new();
            try
            {
                _MsebdgcampsContext.CampDetails.Add(camp);
                await _MsebdgcampsContext.SaveChangesAsync();
                _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                _CampDetailsRespDTO.CampDetailsList = GetAllCampDetailsList().Result.CampDetailsList;
            }
            catch (Exception ex)
            {
                _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE + "-" + ex.ToString();
                _CampDetailsRespDTO.CampDetailsList = null;
            }
            return _CampDetailsRespDTO;
        }

        public async Task<CampDetailsRespDTO> UpdateCampDetailsAsync(CampDetail camp)
        {
            _CampDetailsRespDTO = new();
            try
            {
                var existingCamp = await _MsebdgcampsContext.CampDetails
                    .FirstOrDefaultAsync(x => x.Id == camp.Id);

                if (existingCamp == null)
                {
                    _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.NOTHING_FOUND_TO_UPDATE;
                    _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.NOTHING_FOUND_TO_UPDATE_MESSAGE;
                    _CampDetailsRespDTO.CampDetailsList = null;
                    return _CampDetailsRespDTO;
                }

                // ✅ Update fields
                existingCamp.CampNameEn = camp.CampNameEn;
                existingCamp.CampNameBn = camp.CampNameBn;
                existingCamp.CampTypeId = camp.CampTypeId;
                existingCamp.Country = camp.Country;
                existingCamp.SecommitteeId = camp.SecommitteeId;
                existingCamp.UnitCommitteeId = camp.UnitCommitteeId;
                existingCamp.CampDate = camp.CampDate;
                existingCamp.CampLocationEn = camp.CampLocationEn;
                existingCamp.CampLocationBn = camp.CampLocationBn;
                existingCamp.Coordinator = camp.Coordinator;
                existingCamp.Phone1 = camp.Phone1;
                existingCamp.Active = camp.Active;
                // Add more fields as needed...

                await _MsebdgcampsContext.SaveChangesAsync();

                _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                _CampDetailsRespDTO.CampDetailsList = GetAllCampDetailsList().Result.CampDetailsList;
            }
            catch (Exception ex)
            {
                _CampDetailsRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CampDetailsRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE + " - " + ex.ToString();
                _CampDetailsRespDTO.CampDetailsList = null;
            }

            return _CampDetailsRespDTO;
        }

        public DivisionListRespDTO GetDivisionList()
        {
            _DivisionListRespDTO = new();
            try
            {
                var divion = _MsebdgcampsContext.Divisions.Where(x => x.Active == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (divion != null)
                {
                    _DivisionListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _DivisionListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _DivisionListRespDTO.DivisionList = divion;
                }
                else
                {
                    _DivisionListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _DivisionListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _DivisionListRespDTO.DivisionList = null;
                }
            }
            catch (Exception ex)
            {
                _DivisionListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _DivisionListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _DivisionListRespDTO.DivisionList = null;
            }
            return _DivisionListRespDTO;
        }

        public DivisionListRespDTO GetDivisionListForUpdate()
        {
            _DivisionListRespDTO = new();
            try
            {
                var divion = _MsebdgcampsContext.Divisions.Where(x => x.Active == 1)
                                    .ToList();
                if (divion != null)
                {
                    _DivisionListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _DivisionListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _DivisionListRespDTO.DivisionList = divion;
                }
                else
                {
                    _DivisionListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _DivisionListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _DivisionListRespDTO.DivisionList = null;
                }
            }
            catch (Exception ex)
            {
                _DivisionListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _DivisionListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _DivisionListRespDTO.DivisionList = null;
            }
            return _DivisionListRespDTO;
        }

        public DistrictListRespDTO GetDistrictList(int DivisionId)
        {
            _DistrictListRespDTO = new();
            try
            {
                var districts = _MsebdgcampsContext.Districts.Where(x => x.Active == 1 && x.DivisionId == DivisionId)
                                    .AsNoTracking()
                                    .ToList();
                if (districts != null)
                {
                    _DistrictListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _DistrictListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _DistrictListRespDTO.DistrictList = districts;
                }
                else
                {
                    _DistrictListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _DistrictListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _DistrictListRespDTO.DistrictList = null;
                }
            }
            catch (Exception ex)
            {
                _DistrictListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _DistrictListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _DistrictListRespDTO.DistrictList = null;
            }
            return _DistrictListRespDTO;
        }

        public DistrictListRespDTO GetDistrictListForUpdate(int DivisionId)
        {
            _DistrictListRespDTO = new();
            try
            {
                var districts = _MsebdgcampsContext.Districts.Where(x => x.Active == 1 && x.DivisionId == DivisionId)
                                    .ToList();
                if (districts != null)
                {
                    _DistrictListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _DistrictListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _DistrictListRespDTO.DistrictList = districts;
                }
                else
                {
                    _DistrictListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _DistrictListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _DistrictListRespDTO.DistrictList = null;
                }
            }
            catch (Exception ex)
            {
                _DistrictListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _DistrictListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _DistrictListRespDTO.DistrictList = null;
            }
            return _DistrictListRespDTO;
        }

        public UpazilaListRespDTO GetUpazilaList(int DistrictId)
        {
            _UpazilaListRespDTO = new();
            try
            {
                var upazilas = _MsebdgcampsContext.Upazilas.Where(x => x.Active == 1 && x.DistrictId == DistrictId)
                                    .AsNoTracking()
                                    .ToList();
                if (upazilas != null)
                {
                    _UpazilaListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _UpazilaListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _UpazilaListRespDTO.UpazilaList = upazilas;
                }
                else
                {
                    _UpazilaListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _UpazilaListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _UpazilaListRespDTO.UpazilaList = null;
                }
            }
            catch (Exception ex)
            {
                _UpazilaListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _UpazilaListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _UpazilaListRespDTO.UpazilaList = null;
            }
            return _UpazilaListRespDTO;
        }

        public UpazilaListRespDTO GetUpazilaListForUpdate(int DistrictId)
        {
            _UpazilaListRespDTO = new();
            try
            {
                var upazilas = _MsebdgcampsContext.Upazilas.Where(x => x.Active == 1 && x.DistrictId == DistrictId)
                                    .ToList();
                if (upazilas != null)
                {
                    _UpazilaListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _UpazilaListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _UpazilaListRespDTO.UpazilaList = upazilas;
                }
                else
                {
                    _UpazilaListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _UpazilaListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _UpazilaListRespDTO.UpazilaList = null;
                }
            }
            catch (Exception ex)
            {
                _UpazilaListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _UpazilaListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _UpazilaListRespDTO.UpazilaList = null;
            }
            return _UpazilaListRespDTO;
        }

        public UnionWardListRespDTO GetWardUnionList(int UpazilaId)
        {
            _UnionWardListRespDTO = new();
            try
            {
                var unions = _MsebdgcampsContext.Unions.Where(x => x.Active == 1 && x.UpazillaId == UpazilaId)
                                    .AsNoTracking()
                                    .ToList();
                if (unions != null)
                {
                    _UnionWardListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _UnionWardListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _UnionWardListRespDTO.UnionList = unions;
                }
                else
                {
                    _UnionWardListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _UnionWardListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _UnionWardListRespDTO.UnionList = null;
                }
            }
            catch (Exception ex)
            {
                _UnionWardListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _UnionWardListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _UnionWardListRespDTO.UnionList = null;
            }
            return _UnionWardListRespDTO;
        }

        public UnionWardListRespDTO GetWardUnionListForUpdate(int UpazilaId)
        {
            _UnionWardListRespDTO = new();
            try
            {
                var unions = _MsebdgcampsContext.Unions.Where(x => x.Active == 1 && x.UpazillaId == UpazilaId)
                                    .ToList();
                if (unions != null)
                {
                    _UnionWardListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _UnionWardListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _UnionWardListRespDTO.UnionList = unions;
                }
                else
                {
                    _UnionWardListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _UnionWardListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _UnionWardListRespDTO.UnionList = null;
                }
            }
            catch (Exception ex)
            {
                _UnionWardListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _UnionWardListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _UnionWardListRespDTO.UnionList = null;
            }
            return _UnionWardListRespDTO;
        }

        public CampTypeListRespDTO GetCampTypeList()
        {
            _CampTypeListRespDTO = new();
            try
            {
                var campTypes = _MsebdgcampsContext.CampTypes.Where(x => x.Active == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (campTypes != null)
                {
                    _CampTypeListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _CampTypeListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _CampTypeListRespDTO.CampTypeList = campTypes;
                }
                else
                {
                    _CampTypeListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _CampTypeListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _CampTypeListRespDTO.CampTypeList = null;
                }
            }
            catch (Exception ex)
            {
                _CampTypeListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CampTypeListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _CampTypeListRespDTO.CampTypeList = null;
            }
            return _CampTypeListRespDTO;
        }

        public CampTypeListRespDTO GetCampTypeListForUpdate()
        {
            _CampTypeListRespDTO = new();
            try
            {
                var campTypes = _MsebdgcampsContext.CampTypes.Where(x => x.Active == 1)
                                    .ToList();
                if (campTypes != null)
                {
                    _CampTypeListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _CampTypeListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _CampTypeListRespDTO.CampTypeList = campTypes;
                }
                else
                {
                    _CampTypeListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _CampTypeListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _CampTypeListRespDTO.CampTypeList = null;
                }
            }
            catch (Exception ex)
            {
                _CampTypeListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _CampTypeListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _CampTypeListRespDTO.CampTypeList = null;
            }
            return _CampTypeListRespDTO;
        }

        public BloodGroupListRespDTO GetBloodGroupList()
        {
            _BloodGroupListRespDTO = new();
            try
            {
                var bloodGroups = _MsebdgcampsContext.BloodGroups.Where(x => x.Active == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (bloodGroups != null)
                {
                    _BloodGroupListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _BloodGroupListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _BloodGroupListRespDTO.BloodGroupList = bloodGroups;
                }
                else
                {
                    _BloodGroupListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _BloodGroupListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _BloodGroupListRespDTO.BloodGroupList = null;
                }
            }
            catch (Exception ex)
            {
                _BloodGroupListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _BloodGroupListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _BloodGroupListRespDTO.BloodGroupList = null;
            }
            return _BloodGroupListRespDTO;
        }

        public GenderListRespDTO GetGenderList()
        {
            _GenderListRespDTO = new();
            try
            {
                var genderList = _MsebdgcampsContext.Genders.Where(x => x.Active == 1)
                                    .AsNoTracking()
                                    .ToList();
                if (genderList != null)
                {
                    _GenderListRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _GenderListRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _GenderListRespDTO.GenderList = genderList;
                }
                else
                {
                    _GenderListRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _GenderListRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _GenderListRespDTO.GenderList = null;
                }
            }
            catch (Exception ex)
            {
                _GenderListRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _GenderListRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _GenderListRespDTO.GenderList = null;
            }
            return _GenderListRespDTO;
        }

        public CountryListRespDTO GetCountryList()
        {
            _CountryListResp = new();
            try
            {
                var countryList = _MsebdgcampsContext.CountryMsts
                                    .AsNoTracking()
                                    .OrderBy(c => c.CountryName)
                                    .ToList();
                if (countryList != null)
                {
                    _CountryListResp.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _CountryListResp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _CountryListResp.CountryList = countryList;
                }
                else
                {
                    _CountryListResp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _CountryListResp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _CountryListResp.CountryList = null;
                }
            }
            catch(Exception ex)
            {
                _CountryListResp.RESPONSE_CODE = ConfigClass.FAILURE;
                _CountryListResp.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _CountryListResp.CountryList = null;
            }
            return _CountryListResp;
        }

        public CountryListRespDTO GetCountryListForUpdate()
        {
            _CountryListResp = new();
            try
            {
                var countryList = _MsebdgcampsContext.CountryMsts
                                    .OrderBy(c => c.CountryName)
                                    .ToList();
                if (countryList != null)
                {
                    _CountryListResp.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _CountryListResp.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _CountryListResp.CountryList = countryList;
                }
                else
                {
                    _CountryListResp.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _CountryListResp.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _CountryListResp.CountryList = null;
                }
            }
            catch (Exception ex)
            {
                _CountryListResp.RESPONSE_CODE = ConfigClass.FAILURE;
                _CountryListResp.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _CountryListResp.CountryList = null;
            }
            return _CountryListResp;
        }

        public SECommitteeRespDTO GetSeCommitteeList()
        {
            _SECommitteeRespDTO = new();
            try
            {
                var committeeList = _MsebdgcampsContext.ShahEmdadiaCommittees
                                    .AsNoTracking()
                                    .OrderBy(c => c.SecommitteeNameEn)
                                    .ToList();
                if (committeeList != null)
                {
                    _SECommitteeRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _SECommitteeRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _SECommitteeRespDTO.SECommitteeList = committeeList;
                }
                else
                {
                    _SECommitteeRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _SECommitteeRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _SECommitteeRespDTO.SECommitteeList = null;
                }
            }
            catch (Exception ex)
            {
                _SECommitteeRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _SECommitteeRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _SECommitteeRespDTO.SECommitteeList = null;
            }
            return _SECommitteeRespDTO;
        }

        public SECommitteeRespDTO GetSeCommitteeListForUpdate()
        {
            _SECommitteeRespDTO = new();
            try
            {
                var committeeList = _MsebdgcampsContext.ShahEmdadiaCommittees
                                    .OrderBy(c => c.SecommitteeNameEn)
                                    .ToList();
                if (committeeList != null)
                {
                    _SECommitteeRespDTO.RESPONSE_CODE = ConfigClass.SUCCESS;
                    _SECommitteeRespDTO.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
                    _SECommitteeRespDTO.SECommitteeList = committeeList;
                }
                else
                {
                    _SECommitteeRespDTO.RESPONSE_CODE = ConfigClass.DATA_NOT_FOUND;
                    _SECommitteeRespDTO.RESPONSE_DESCRPTION = ConfigClass.DATA_NOT_FOUND_MESSAGE;
                    _SECommitteeRespDTO.SECommitteeList = null;
                }
            }
            catch (Exception ex)
            {
                _SECommitteeRespDTO.RESPONSE_CODE = ConfigClass.FAILURE;
                _SECommitteeRespDTO.RESPONSE_DESCRPTION = ConfigClass.FAILURE_MESSAGE;
                _SECommitteeRespDTO.SECommitteeList = null;
            }
            return _SECommitteeRespDTO;
        }
    }
}
