using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSUser
    {
        int GetID();

        bool Login();

        void Logout();
    }
}