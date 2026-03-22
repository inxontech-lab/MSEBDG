using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class Allergy
{
    public int AllergyId { get; set; }

    public string AllergyName { get; set; } = null!;

    public string? AllergyType { get; set; }

    public string? Description { get; set; }

    public int IsActive { get; set; }
}
