using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class BeneficiaryQuestionAnswer
{
    public int AnswerId { get; set; }

    public int BeneficiaryId { get; set; }

    public int QuestionId { get; set; }

    public int AnswerYesNo { get; set; }

    public string? AnswerText { get; set; }

    public decimal? AnswerNumeric { get; set; }

    public int AnswerOptionId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
