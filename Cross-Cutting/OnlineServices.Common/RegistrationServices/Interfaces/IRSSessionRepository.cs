using OnlineServices.Common.RegistrationServices.TransferObject;

using System;
using System.Collections.Generic;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSSessionRepository : OnlineServices.Common.DataAccessHelpers.IRepository<SessionTO, int>
    {
        IEnumerable<UserTO> GetStudents(SessionTO session);

        IEnumerable<DateTime> GetDates(SessionTO session);
    }
}