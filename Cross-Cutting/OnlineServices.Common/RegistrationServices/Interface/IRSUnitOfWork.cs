using AttendanceServices.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices.Interface
{
    public interface IRSUnitOfWork :IUnitOfWork
    {
        IRSSessionRepository SessionRepository { get; }
        IRSUserRepository UserRepository { get; }
    }
}