using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.BusinessLayer.UseCases
{
    public partial class ESAttendeeRole : IESAttendeeRole
    {
        public FormQuestionTO GetFormById(int sessionID, int formID)
        {
            //Etape 1 : Verifier parameter
            if (!iESUnitOfWork.QuestionRepository.GetAll().Any(x => x.Id == formID))
                throw new Exception("Formulaire inexistant");
            if (!userService.IsExistentSession(sessionID))
                throw new Exception("Session inexistant");
            return iESUnitOfWork.QuestionRepository.GetById(formID);
        }
    }
}
