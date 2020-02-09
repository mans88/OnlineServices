using OnlineServices.Common.RegistrationServices.TransferObject;

using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices
{
    public interface IASAttendeeRole
    {
        bool CheckIn(int sessionId, int attendeeId);
    }
}
