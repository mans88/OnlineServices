//using OnlineServices.Common.EvaluationServices;
//using OnlineServices.Common.EvaluationServices.TransfertObjects;
//using OnlineServices.Common.Extensions;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace EvaluationServices.BusinessLayer.UseCases.AssitantRole
//{
//    public partial class ESAssistantRole : IESAssistantRole
//    {
//        public FormTO2 GetActiveForm(int sessionId, int attendeeId)
//        {
//            //Etape Tester
//            var session = iRSServiceRole.GetSession(sessionId);

//            //1. User is in session
//            if (!session.Attendees.Any(x => x.Id == attendeeId))
//                throw new Exception("User is not in session");

//            //2. Si Ajourd'hui est jour de formulaire
//            if (session.SessionDays.Any(x => x.Date.IsSameDate(DateTime.Now)))
//            {
//                var min = session.SessionDays.Min(x => x.Date);
//                var max = session.SessionDays.Max(x => x.Date);

//                if (min.IsSameDate(DateTime.Now))
//                {
//                    // 3a. Already Questions submitted
//                    return IsSubmitted(sessionId, attendeeId, 1);
//                }

//                else if (max.IsSameDate(DateTime.Now))
//                {
//                    // 3b. Already Questions submitted
//                    return IsSubmitted(sessionId, attendeeId, 2);
//                }
//                return null;
//            }

//            else
//                throw new Exception("Session is not held today.");
//        }

//        private List<ResponseTO> IsSubmitted(int sessionId, int attendeeId, int formId)
//        {
//            if (iESUnitOfWork.SubmissionRepository.IsAlreadySubmitted(attendeeId, sessionId, formId))
//                throw new Exception("User already submitted.");
//            return iESUnitOfWork.ResponseRepository.GetAllOfForm(formId).ToList();
//        }

//    }
//}
