using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public QuestionTO GetQuestionById(int questionID)
        {
            return iESUnitOfWork.QuestionRepository.GetById(questionID);
        }
    }
}
