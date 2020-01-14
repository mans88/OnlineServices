using OnlineServices.Common.AttendanceServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices
{
    public interface IASAssistantRole
    {
        bool SetPresence(AttendeePresenceTO presenceTO);
        List<AttendeePresenceTO> GetAttendeePresence(int formationID, int attendeeID);
        List<AttendeePresenceTO> GetFormationPresence(int formationID);
    }
}
