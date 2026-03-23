using Domain.CampsModels.DBModels;

namespace Domain.CampsModels.RespDTO;

public class CampaignVolunteerListRespDTO
{
    public string? RESPONSE_CODE { get; set; }
    public string? RESPONSE_DESCRPTION { get; set; }
    public List<CampaignVolunteerDto>? VolunteerList { get; set; }
}
