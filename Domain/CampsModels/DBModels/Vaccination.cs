using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class Vaccination
{
    public int VaccinationId { get; set; }

    public string VaccineName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsMandatory { get; set; }

    public int IsActive { get; set; }
}
