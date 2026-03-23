using Domain.CampsModels.DBModels;

namespace Domain.CampsModels.RespDTO;

public class CampaignVolunteerRespDTO
{
    public string? RESPONSE_CODE { get; set; }
    public string? RESPONSE_DESCRPTION { get; set; }
    public CampaignVolunteer? Volunteer { get; set; }
}
