using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public FormTO GetFormById(int formID)
        {
            return iESUnitOfWork.FormRepository.GetById(formID);
        }
    }
}
