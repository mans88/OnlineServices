using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices
{
    public interface IRSAttendeeRole
    {
        public SessionTO GetTodaySession(int userId);

        public int GetIdByMail(string email);
    }
}