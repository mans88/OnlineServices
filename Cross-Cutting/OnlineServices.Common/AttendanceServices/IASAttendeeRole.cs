using OnlineServices.Common.RegistrationServices.TransferObject;

using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices
{
    public interface IASAttendeeRole
    {
        bool SetPresence(int formationID, int attendeeID);
        List<SessionTO> GetTodaySessions();
    }
}
