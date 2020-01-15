using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices
{
    public interface IRSServiceRole
    {
        bool IsUserInSession(int userId, int sessionId);
        List<UserTO> GetSessionAttendes(int sessionId);
        SessionTO GetSession(int sessionId);
    }
}
