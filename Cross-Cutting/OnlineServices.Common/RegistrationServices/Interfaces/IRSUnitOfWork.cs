using AttendanceServices.DataLayer;
using OnlineServices.Common.RegistrationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSUnitOfWork : IUnitOfWork
    {
         IRSSessionRepository SessionRepository { get; }
         IRSUserRepository UserRepository { get; }
         IRSCourseRepository CourseRepository { get; }
    }
}