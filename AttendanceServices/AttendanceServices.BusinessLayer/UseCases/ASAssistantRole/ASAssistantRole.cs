using AttendanceService.DataLayer;
using OnlineServices.Common.AttendanceServices;
using System;
using System.Collections.Generic;

namespace AttendanceServices.BusinessLayer
{
    public class ASAssistantRole: IASAssistantRole
    {
        private IRSServiceRole registrationService;

        public AssistantRole(IRSServiceRole registrationService)
        {
            this.registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
        }

        public AttendeePresenceTO GetAttendeePresence(int sessionID, int attendeeID)
        {
            if (sessionID <= 0)
                throw new Exception("SessionId must be greater then 0");
            if (attendeeID <= 0)
                throw new Exception("AttendeeId must be greater then 0");

            return GetSessionPresence(sessionID).First(x => x.attendeeID == attendeeID);
        }

        public List<AttendeePresenceTO> GetSessionPresence(int sessionId)
        {
            if (sessionId <= 0)
                throw new Exception("SessionId must be greater then 0");

            var listUser = registrationService.GetUserInSession(sessionId);

            var listPresence = new List<AttendeePresenceTO>();

            using (var UoW = new ASUnitOfWork())
            {

                //listPresence = QUERY REPO NATHAN..
            }

            return listPresence;
        }

        public bool SetPresence(int formationID, int attendeeID, DateTime MomentPresence)
        {
            throw new NotImplementedException();
        }
    }
}