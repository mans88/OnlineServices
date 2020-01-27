using OnlineServices.Common.RegistrationServices.Interfaces;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationServices.DataLayer
{
    public class RegistrationServicesUnitOfWork : IRSUnitOfWork
    {
        private readonly RegistrationServicesContext registrationContext;

        public RegistrationServicesUnitOfWork(RegistrationServicesContext context)
        {
            this.registrationContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IRSSessionRepository sessionRepository;

        public IRSSessionRepository SessionRepository
          => sessionRepository ??= (IRSSessionRepository)new SessionRepository(registrationContext);

        private IRSUserRepository userRepository;

        public IRSUserRepository UserRepository
            => userRepository ??= new UserRepository(registrationContext);

        public IRSCourseRepository courseRepository;

        public IRSCourseRepository CourseRepository
            => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}