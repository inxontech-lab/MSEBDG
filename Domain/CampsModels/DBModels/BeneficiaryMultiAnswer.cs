using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class BeneficiaryMultiAnswer
{
    public int BeneficiaryId { get; set; }

    public int QuestionId { get; set; }

    public int OptionId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
