using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.CampsModels.DBModels;

public partial class CampaignVolunteer
{
    public int VolunteerId { get; set; }

    public string FullNameEn { get; set; } = null!;

    public string FullNameBn { get; set; } = null!;

    public string FatherNameEn { get; set; } = null!;

    public string? FatherNameBn { get; set; }

    public string MotherNameEn { get; set; } = null!;

    public string? MotherNameBn { get; set; }

    public int GenderId { get; set; }

    public int BloodGroupId { get; set; }

    public int DivisionId { get; set; }

    public int ZillaId { get; set; }

    public int ThanaId { get; set; }

    public int VillageId { get; set; }

    public string PostOfficeName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? WhatsAppNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? UnitCommitteeName { get; set; }

    public int BloodDonationsCount { get; set; }

    public int GroupingCampParticipationCount { get; set; }

    public string? PhotoLocation { get; set; }

    public bool Active { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    [JsonIgnore]
    public virtual BloodGroup? BloodGroup { get; set; }

    [JsonIgnore]
    public virtual Gender? Gender { get; set; }
}
