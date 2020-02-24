using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public bool RemovePropositionById(int propositionId)
        {
            var result = iESUnitOfWork.QuestionPropositionRepository.Remove(propositionId);
            return iESUnitOfWork.SaveChanges()>0;
        }
    }
}
