using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class QuestionMultipleChoice : QuestionsTO
    {
        public bool IsMultipleChoice { get; set; }
        public Dictionary<int, string> Choices { get; set; }
    }
}
