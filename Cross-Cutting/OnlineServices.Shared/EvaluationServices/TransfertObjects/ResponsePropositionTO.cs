using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace OnlineServices.Common.EvaluationServices
{
    public class ResponsePropositionTO : IEntity<int>
    {
        public int Id { get; set; }
        public ResponseTO Response { get; set; }
        public QuestionPropositionTO QuestionProposition { get;set; }
    }
}