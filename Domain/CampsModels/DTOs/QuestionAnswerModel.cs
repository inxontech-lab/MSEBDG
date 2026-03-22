using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CampsModels.DTOs
{
    public class QuestionAnswerModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;

        public string QuestionType { get; set; } = string.Empty;

        // Yes/No or Checkbox
        public bool? AnswerYesNo { get; set; }

        // Text Answer
        public string? AnswerText { get; set; }

        // Multi-select
        public List<QuestionOptionModel> Options { get; set; } = new();
        public List<int> SelectedOptionIds { get; set; } = new();
    }

    public class QuestionOptionModel
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; } = string.Empty;
    }
}
