using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IESAssistantRole
    {
        public List<FormTO> GetAllForms()
        {
            return iESUnitOfWork.FormRepository.GetAll().ToList();
        }
    }
}
