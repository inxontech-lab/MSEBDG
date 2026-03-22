using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class Beneficiary
{
    public int Id { get; set; }

    public int? CampId { get; set; }

    public string? MobileNumber { get; set; }

    public string FullName { get; set; } = null!;

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public int? GenderId { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Age { get; set; }

    public int? BloodGroup { get; set; }

    public string? NationalId { get; set; }

    public string? HeightFeet { get; set; }

    public string? HeightInch { get; set; }

    public string? HeightInCm { get; set; }

    public string? Weight { get; set; }

    public string? Bmi { get; set; }

    public int? TimesDonated { get; set; }

    public string? Education { get; set; }

    public int? DivisionId { get; set; }

    public int? DistrictId { get; set; }

    public int? UpazilaId { get; set; }

    public int? WardUnionId { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public int? Active { get; set; }

    public int? CreatebBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
