using DataAccess.CampsRepo;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class CampaignVolunteerService
    {
        private readonly IGroupingCampContextDataRepo _groupingCampContextDataRepo;

        public CampaignVolunteerService(IGroupingCampContextDataRepo groupingCampContextDataRepo)
        {
            _groupingCampContextDataRepo = groupingCampContextDataRepo;
        }

        public Task<CampaignVolunteerListRespDTO> GetCampaignVolunteerListAsync(bool activeOnly = false)
        {
            return _groupingCampContextDataRepo.GetCampaignVolunteerListAsync(activeOnly);
        }

        public Task<CampaignVolunteerRespDTO> GetCampaignVolunteerByIdAsync(int volunteerId)
        {
            return _groupingCampContextDataRepo.GetCampaignVolunteerByIdAsync(volunteerId);
        }

        public Task<CampaignVolunteerListRespDTO> SaveCampaignVolunteerAsync(CampaignVolunteer volunteer)
        {
            return _groupingCampContextDataRepo.SaveCampaignVolunteerAsync(volunteer);
        }

        public Task<CampaignVolunteerListRespDTO> UpdateCampaignVolunteerAsync(CampaignVolunteer volunteer)
        {
            return _groupingCampContextDataRepo.UpdateCampaignVolunteerAsync(volunteer);
        }

        public Task<CampaignVolunteerListRespDTO> DeleteCampaignVolunteerAsync(int volunteerId)
        {
            return _groupingCampContextDataRepo.DeleteCampaignVolunteerAsync(volunteerId);
        }
    }
}
