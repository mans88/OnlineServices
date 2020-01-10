using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSTrainer
    {
        List<SessionTO> GetSessions(List<DateTime> dates);
        List<UserTO> GetStudents(int sessionId);
    }
}
