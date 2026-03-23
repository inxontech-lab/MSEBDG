namespace Domain.CampsModels.RespDTO;

public class CampaignVolunteerProfileDto
{
    public int VolunteerId { get; set; }
    public string FullNameEn { get; set; } = string.Empty;
    public string FullNameBn { get; set; } = string.Empty;
    public string FatherNameEn { get; set; } = string.Empty;
    public string? FatherNameBn { get; set; }
    public string MotherNameEn { get; set; } = string.Empty;
    public string? MotherNameBn { get; set; }
    public string GenderName { get; set; } = string.Empty;
    public string BloodGroupName { get; set; } = string.Empty;
    public string DivisionName { get; set; } = string.Empty;
    public string ZillaName { get; set; } = string.Empty;
    public string ThanaName { get; set; } = string.Empty;
    public string VillageName { get; set; } = string.Empty;
    public string PostOfficeName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? WhatsAppNumber { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? UnitCommitteeName { get; set; }
    public int BloodDonationsCount { get; set; }
    public int GroupingCampParticipationCount { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? PhotoLocation { get; set; }
    public string? PhotoBase64 { get; set; }
    public string? PhotoMimeType { get; set; }
}
