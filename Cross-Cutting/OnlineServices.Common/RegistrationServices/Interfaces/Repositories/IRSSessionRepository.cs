using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.RegistrationServices.TransferObject;

using System;
using System.Collections.Generic;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSSessionRepository : IRepository<SessionTO, int>
    {
        IEnumerable<SessionTO> GetByUser(UserTO user);

        IEnumerable<DateTime> GetDates(SessionTO session);

        IEnumerable<SessionTO> GetSessionsByDate(DateTime date);
    }
}