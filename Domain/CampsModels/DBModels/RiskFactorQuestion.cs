using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class RiskFactorQuestion
{
    public int RiskFactorId { get; set; }

    public string QuestionTextEn { get; set; } = null!;

    public string? QuestionTextBn { get; set; }

    public string? QuestionType { get; set; }

    public int? IsActive { get; set; }
}
