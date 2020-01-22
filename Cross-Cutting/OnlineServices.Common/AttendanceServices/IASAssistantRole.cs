using OnlineServices.Common.AttendanceServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices
{
    public interface IASAssistantRole
    {
        bool SetPresence(int sessionId, int attendeeId, DateTime presenceTime); // REVIEW if necessry to have PresenceArgs or a type presence on others classes aswell
        List<AttendeePresenceTO> GetPresenceOfAttendee(int sessionId, int attendeeId);
        List<AttendeePresenceTO> GetPresencesInSession(int sessionId);
    }
}
