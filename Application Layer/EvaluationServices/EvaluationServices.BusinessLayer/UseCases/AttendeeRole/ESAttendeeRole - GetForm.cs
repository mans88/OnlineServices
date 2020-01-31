using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationServices.BusinessLayer.UseCases
{
    public partial class ESAttendeeRole : IESAttendeeRole
    {
        public FormTO2 GetActiveForm(int sessionId, int attendeeId)
        {
            //Etape Tester
            var session = iRSServiceRole.GetSession(sessionId);

            //1. User is in session
            if (!session.Attendees.Any(x => x.Id == attendeeId))
                throw new LoggedException("User is not in session");

            //2. Si Ajourd'hui est jour de formulaire
            if (session.SessionDays.Any(x => x.Date.IsSameDate(DateTime.Now)))
            {
                var min = session.SessionDays.Min(x => x.Date);
                var max = session.SessionDays.Max(x => x.Date);

                if (min.IsSameDate(DateTime.Now))
                {
                    // 3a. Already Questions submitted
                    if (iESUnitOfWork.SubmissionRepository.IsAlreadySubmitted(attendeeId, sessionId, 1))
                        throw new LoggedException("User already submitted.");
                    if (iESUnitOfWork.SubmissionRepository.IsAlreadySubmitted(attendeeId, sessionId, 2))
                        throw new LoggedException("User cannot submit this initial form after the final evaluation is already submitted.");

                    return FormBuilder(1);
                }

                else if (max.IsSameDate(DateTime.Now))
                {
                    // 3b. Already Questions submitted
                    if (iESUnitOfWork.SubmissionRepository.IsAlreadySubmitted(attendeeId, sessionId, 2))
                        throw new LoggedException("User already submitted.");

                    return FormBuilder(2);
                }

                return null;
            }

            else
                throw new LoggedException("Session is not held today.");
        }

        public FormTO2 FormBuilder(int FormId)
        {
            var ReturnValue = iESUnitOfWork.FormRepository.GetById(FormId);
            return new FormTO2()
            {
                Id = ReturnValue.Id,
                Name = ReturnValue.Name,
                Questions = iESUnitOfWork.QuestionRepository.GetAllOfForm(FormId).ToList()
            };
        }
    }
}

