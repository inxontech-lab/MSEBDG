using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class QuestionOption
{
    public int OptionId { get; set; }

    public int QuestionId { get; set; }

    public string OptionText { get; set; } = null!;

    public bool IsActive { get; set; }
}
