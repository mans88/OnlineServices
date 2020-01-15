using OnlineServices.Common.RegistrationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.RegistrationServices.Interface
{
    public interface IRSUnitOfWork
    {
         IRSSessionRepository SessionRepository { get; }
         IRSUserRepository UserRepository { get; }
         IRSCourseRepository CourseRepository { get; }

        void Dispose();

        void Save();
    }
}