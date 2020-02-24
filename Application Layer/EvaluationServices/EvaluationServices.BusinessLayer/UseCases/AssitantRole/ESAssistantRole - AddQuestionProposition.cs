using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public bool AddPropositionByQuestion(QuestionPropositionTO propositionTO)
        {
            var result = iESUnitOfWork.QuestionPropositionRepository.Add(propositionTO);
            return iESUnitOfWork.SaveChanges() > 0;
        }
    }
}
