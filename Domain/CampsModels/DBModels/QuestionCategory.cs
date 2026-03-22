using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class QuestionCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}
