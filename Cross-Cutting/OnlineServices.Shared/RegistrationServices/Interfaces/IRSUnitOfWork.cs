using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
     public interface IRSUnitOfWork
    {
         IRSSessionRepository SessionRepository { get; }
         IRSUserRepository UserRepository { get; }

        void Dispose();

        void Save();
    }
}