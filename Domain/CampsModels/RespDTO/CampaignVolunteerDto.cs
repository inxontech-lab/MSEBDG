using System;

namespace Domain.CampsModels.RespDTO;

public class CampaignVolunteerDto
{
    public int VolunteerId { get; set; }
    public string FullNameEn { get; set; } = string.Empty;
    public string FullNameBn { get; set; } = string.Empty;
    public string FatherNameEn { get; set; } = string.Empty;
    public string? FatherNameBn { get; set; }
    public string MotherNameEn { get; set; } = string.Empty;
    public string? MotherNameBn { get; set; }
    public int GenderId { get; set; }
    public string GenderName { get; set; } = string.Empty;
    public int BloodGroupId { get; set; }
    public string BloodGroupName { get; set; } = string.Empty;
    public int DivisionId { get; set; }
    public string DivisionName { get; set; } = string.Empty;
    public int ZillaId { get; set; }
    public string ZillaName { get; set; } = string.Empty;
    public int ThanaId { get; set; }
    public string ThanaName { get; set; } = string.Empty;
    public int VillageId { get; set; }
    public string VillageName { get; set; } = string.Empty;
    public string PostOfficeName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? WhatsAppNumber { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? UnitCommitteeName { get; set; }
    public int BloodDonationsCount { get; set; }
    public int GroupingCampParticipationCount { get; set; }
    public string? PhotoLocation { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
