using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.DataAccessHelpers;

namespace OnlineServices.Common.RegistrationServices.Interface
{
    public interface IRSSessionRepository : OnlineServices.Common.DataAccessHelpers.IRepository<SessionTO, int>
    {
        IEnumerable<UserTO> GetStudents(SessionTO session);

        IEnumerable<DateTime> GetDates(SessionTO session);
    }
}