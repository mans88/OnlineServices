using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class QuestionMultipleChoice : QuestionTO
    {
        public bool IsMultipleChoice { get; set; }
        public Dictionary<int, string> Choices { get; set; }
    }
}
