using OnlineServices.Common.EvaluationServices;
using System;
using System.Linq;


namespace EvaluationServices.BusinessLayer.UseCases
{
    public partial class ESAttendeeRole : IESAttendeeRole
    {
        public bool SetResponse(FormResponseTO form)
        {
            //Etape 1 : Verifier parameter
            //if (!iESUnitOfWork.ResponseRepository.GetAll().Any(x => x.Id == form.FormModelID))
            //    throw new Exception("Formulaire inexistant");
            if (!userService.IsExistentSession(form.SessionID))
                throw new Exception("Session inexistant");

            try
            {
                iESUnitOfWork.ResponseRepository.Add(form);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
