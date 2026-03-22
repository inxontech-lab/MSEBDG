using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class MedicalCondition
{
    public int ConditionId { get; set; }

    public string ConditionName { get; set; } = null!;

    public string? ConditionCategory { get; set; }

    public string? Description { get; set; }

    public int IsActive { get; set; }
}
