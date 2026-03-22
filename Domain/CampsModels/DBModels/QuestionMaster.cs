using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class QuestionMaster
{
    public int QuestionId { get; set; }

    public int CategoryId { get; set; }

    public string QuestionTextEn { get; set; } = null!;

    public string? QuestionTextBn { get; set; }

    public string QuestionType { get; set; } = null!;

    public bool IsActive { get; set; }
}
