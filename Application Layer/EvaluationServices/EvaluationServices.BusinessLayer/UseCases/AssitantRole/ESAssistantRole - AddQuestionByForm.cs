using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public bool AddQuestionByForm(QuestionTO questionTO)
        {
            var result =  iESUnitOfWork.QuestionRepository.Add(questionTO);
            return iESUnitOfWork.SaveChanges()>0;
        }
    }
}
