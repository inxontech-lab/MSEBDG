namespace Domain.CampsModels.RespDTO;

public class CampaignVolunteerProfileDto
{
    public int VolunteerId { get; set; }
    public string FullNameEn { get; set; } = string.Empty;
    public string FullNameBn { get; set; } = string.Empty;
    public string ThanaName { get; set; } = string.Empty;
    public string ZillaName { get; set; } = string.Empty;
    public string DivisionName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? UnitCommitteeName { get; set; }
    public int BloodDonationsCount { get; set; }
    public int GroupingCampParticipationCount { get; set; }
    public string? PhotoBase64 { get; set; }
    public string? PhotoMimeType { get; set; }
}
