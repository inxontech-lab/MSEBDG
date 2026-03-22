using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class MedicalConditionCategory
{
    public int Id { get; set; }

    public string? MedicalConditionCategory1 { get; set; }

    public int? Active { get; set; }
}
