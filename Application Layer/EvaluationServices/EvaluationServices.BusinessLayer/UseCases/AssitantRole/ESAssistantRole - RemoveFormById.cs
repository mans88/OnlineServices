using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public bool RemoveFormById(int formID)
        {
            var result = iESUnitOfWork.FormRepository.Remove(formID);
            return iESUnitOfWork.SaveChanges()>0;
        }
    }
}
