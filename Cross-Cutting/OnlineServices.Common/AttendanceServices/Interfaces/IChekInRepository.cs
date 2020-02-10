using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.DataAccessHelpers;
using System.Collections.Generic;

namespace OnlineServices.AttendanceServices.Interfaces
{
    public interface ICheckInRepository
    {
        CheckInTO Add(CheckInTO Entity);
        List<CheckInTO> GetCheckInsInSession(int SessionId);
        List<CheckInTO> GetAttendeeCheckIns(int AttendeeId);
    }
}