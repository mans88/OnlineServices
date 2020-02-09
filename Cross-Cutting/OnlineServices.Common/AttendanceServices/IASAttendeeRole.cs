using OnlineServices.Common.RegistrationServices.TransferObject;

using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices
{
    public interface IASAttendeeRole
    {
        bool SetPresence(int sessionId, int attendeeId);
        List<SessionTO> GetTodaySessions();
    }
}
