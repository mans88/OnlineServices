using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole : IESAttendeeRole
    {
        public FormTO GetForm(int sessionID, int FormModelID)
        {
            //Etape 1 : Verifier parameter
            if (!questionRepository.GetAll().Any(x => x.Id == FormModelID))
                throw new Exception("Formulaire inexistant");
            if (!userService.IsExistentSession(sessionID))
                throw new Exception("Session inexistant");

            //Return values
            return questionRepository.GetById(FormModelID);
        }
    }
}
