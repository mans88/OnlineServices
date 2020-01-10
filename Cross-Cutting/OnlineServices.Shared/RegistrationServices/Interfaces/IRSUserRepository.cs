using OnlineServices.Common.DataAccessHelpers;
using System.Collections.Generic;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace OnlineServices.Common.RegistrationServices.Interfaces 
{ 
     public interface IRSUserRepository : IRepository<UserTO, int>
    {
        IEnumerable<SessionTO> GetSessions(UserTO user);

        IEnumerable<UserTO> GetByRole(UserRole role);

        IEnumerable<UserTO> GetBySession(SessionTO session);

        bool IsInSession(UserTO user, SessionTO session);
    }
}