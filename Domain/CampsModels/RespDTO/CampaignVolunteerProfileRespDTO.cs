namespace Domain.CampsModels.RespDTO;

public class CampaignVolunteerProfileRespDTO
{
    public string? RESPONSE_CODE { get; set; }
    public string? RESPONSE_DESCRPTION { get; set; }
    public CampaignVolunteerProfileDto? Volunteer { get; set; }
}
