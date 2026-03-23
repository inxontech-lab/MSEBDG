using Domain.CampsModels.DBModels;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Mvc;
using MSEBDGAPI.Services.Camps.Master;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class CampaignVolunteerController : ControllerBase
    {
        private readonly CampaignVolunteerService _campaignVolunteerService;

        public CampaignVolunteerController(CampaignVolunteerService campaignVolunteerService)
        {
            _campaignVolunteerService = campaignVolunteerService;
        }

        [Route("api/[controller]/GetCampaignVolunteerList/{activeOnly}")]
        [HttpGet]
        public Task<CampaignVolunteerListRespDTO> GetCampaignVolunteerList(bool activeOnly = false)
        {
            return _campaignVolunteerService.GetCampaignVolunteerListAsync(activeOnly);
        }

        [Route("api/[controller]/GetCampaignVolunteerById/{volunteerId}")]
        [HttpGet]
        public Task<CampaignVolunteerRespDTO> GetCampaignVolunteerById(int volunteerId)
        {
            return _campaignVolunteerService.GetCampaignVolunteerByIdAsync(volunteerId);
        }

        [Route("api/[controller]/SaveCampaignVolunteerAsync")]
        [HttpPost]
        public Task<CampaignVolunteerListRespDTO> SaveCampaignVolunteerAsync([FromBody] CampaignVolunteer volunteer)
        {
            return _campaignVolunteerService.SaveCampaignVolunteerAsync(volunteer);
        }

        [Route("api/[controller]/UpdateCampaignVolunteerAsync")]
        [HttpPost]
        public Task<CampaignVolunteerListRespDTO> UpdateCampaignVolunteerAsync([FromBody] CampaignVolunteer volunteer)
        {
            return _campaignVolunteerService.UpdateCampaignVolunteerAsync(volunteer);
        }

        [Route("api/[controller]/DeleteCampaignVolunteerAsync/{volunteerId}")]
        [HttpDelete]
        public Task<CampaignVolunteerListRespDTO> DeleteCampaignVolunteerAsync(int volunteerId)
        {
            return _campaignVolunteerService.DeleteCampaignVolunteerAsync(volunteerId);
        }
    }
}
