using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CampsRepo
{
    public interface IGroupingCampContextDataRepo : IDisposable
    {
        Task<CampDetailsRespDTO> GetAllCampDetailsList();
        Task<BeneficiaryInfoRespDTO> GetBeneficiaryByMobile(string MobileNumber);
        Task<CommonRespDTO> UpdateBloodGroupByMobile(int BloodGroup, string MobileNumber);
        Task<CommonRespDTO> SaveBeneficiaryDetailsAsync(BeneficiaryDetailsReqDTO reqDTO);
        List<QuestionMaster> GetQuestionList();
        FemaleQuestionsRespDTO GetFemaleDonorQuestions();
        RiskFactorQuestRespDTO GetRiskFactQuestions();
        MedicalConsitonListRespDTO GetMedicalConditonList();
        GeneralHealthQuestionRespDTO GetGeneralHealtQuestions();
        Task<CampDetailsRespDTO> GetCampDetailsList(int? campId, int? campTypeId, int? seCommitteeId, int? unitCommitteeId, string? campDateString);
        Task<CampDetailsRespDTO> SaveCampDetailsAsync(CampDetail camp);
        Task<CampDetailsRespDTO> UpdateCampDetailsAsync(CampDetail camp);
        Task<CampaignVolunteerListRespDTO> GetCampaignVolunteerListAsync(bool activeOnly = false);
        Task<CampaignVolunteerRespDTO> GetCampaignVolunteerByIdAsync(int volunteerId);
        Task<CampaignVolunteerListRespDTO> SaveCampaignVolunteerAsync(CampaignVolunteer volunteer);
        Task<CampaignVolunteerListRespDTO> UpdateCampaignVolunteerAsync(CampaignVolunteer volunteer);
        Task<CampaignVolunteerListRespDTO> DeleteCampaignVolunteerAsync(int volunteerId);
        DivisionListRespDTO GetDivisionList();
        DivisionListRespDTO GetDivisionListForUpdate();
        DistrictListRespDTO GetDistrictList(int DivisionId);
        DistrictListRespDTO GetDistrictListForUpdate(int DivisionId);
        UpazilaListRespDTO GetUpazilaList(int DistrictId);
        UpazilaListRespDTO GetUpazilaListForUpdate(int DistrictId);
        UnionWardListRespDTO GetWardUnionList(int UpazilaId);
        UnionWardListRespDTO GetWardUnionListForUpdate(int UpazilaId);
        CampTypeListRespDTO GetCampTypeList();
        CampTypeListRespDTO GetCampTypeListForUpdate();
        BloodGroupListRespDTO GetBloodGroupList();
        GenderListRespDTO GetGenderList();
        CountryListRespDTO GetCountryList();
        CountryListRespDTO GetCountryListForUpdate();
        SECommitteeRespDTO GetSeCommitteeList();
        SECommitteeRespDTO GetSeCommitteeListForUpdate();
    }
}
