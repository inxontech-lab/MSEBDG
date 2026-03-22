using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class DeclarationMst
{
    public int DeclarationId { get; set; }

    public string DeclarationTextEn { get; set; } = null!;

    public string? DeclarationTextBn { get; set; }

    public int IsActive { get; set; }

    public int? DisplayOrder { get; set; }
}
