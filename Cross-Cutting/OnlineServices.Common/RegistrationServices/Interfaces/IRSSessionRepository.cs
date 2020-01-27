using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.RegistrationServices.TransferObject;

using System;
using System.Collections.Generic;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSSessionRepository : IRepository<SessionTO, int>
    {
        IEnumerable<UserTO> GetStudents(SessionTO session);

        IEnumerable<DateTime> GetDates(SessionTO session);
    }
}