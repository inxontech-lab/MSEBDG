using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class BenificieryGeneralHealth
{
    public int AnswerId { get; set; }

    public int BenificieryId { get; set; }

    public int QuestionId { get; set; }

    public string? AnswerValue { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }
}
