using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class BeneficiaryAnswer
{
    public int Id { get; set; }

    public int BeneficiaryId { get; set; }

    public int QuestionId { get; set; }

    public string? AnswerValue { get; set; }

    public DateTime? CreatedOn { get; set; }
}
