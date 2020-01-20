using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices
{
    public class ResponseTO
    {
        public int Id { get; set; }
        public FormResponseTO Form { get; set; }
        public QuestionTO Question { get; set; }
        public virtual List<ResponsePropositionTO> Choices { get; set; }
        public string ResponseOpened { get; set; }
    }
}