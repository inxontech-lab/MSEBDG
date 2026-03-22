using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class Medication
{
    public int MedicationId { get; set; }

    public string MedicationName { get; set; } = null!;

    public string? Purpose { get; set; }

    public int IsActive { get; set; }
}
