using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Mvc;
using MSEBDGAPI.Services.Camps.Master;

namespace CampsAPI.Controllers.Master;

[ApiController]
public class VolunteerProfileController : ControllerBase
{
    private readonly VolunteerProfileService _volunteerProfileService;

    public VolunteerProfileController(VolunteerProfileService volunteerProfileService)
    {
        _volunteerProfileService = volunteerProfileService;
    }

    [HttpGet]
    [Route("api/[controller]/GetVolunteerProfile/{volunteerId:int}")]
    public Task<CampaignVolunteerProfileRespDTO> GetVolunteerProfile(int volunteerId)
    {
        return _volunteerProfileService.GetVolunteerProfileAsync(volunteerId);
    }
}
