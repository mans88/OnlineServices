using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public bool AddForm(FormTO form)
        {
            iESUnitOfWork.FormRepository.Add(form);
            return iESUnitOfWork.SaveChanges()>0;
            
        }
    }
}
