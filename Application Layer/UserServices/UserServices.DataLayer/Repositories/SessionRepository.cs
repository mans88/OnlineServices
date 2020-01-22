using OnlineServices.Common.RegistrationServices.Interface;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationServices.DataLayer.Repositories
{
    class SessionRepository : IRSSessionRepository
    {
        private readonly RegistrationServicesContext sessionContext;

        public SessionRepository(RegistrationServicesContext Context)
        {
            sessionContext = Context ?? throw new ArgumentNullException($"{nameof(Context)} in UserRepository");
        }

        public SessionTO Add(SessionTO Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessionTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public SessionTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateTime> GetDates(SessionTO session)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTO> GetStudents(SessionTO session)
        {
            throw new NotImplementedException();
        }

        public bool Remove(SessionTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public SessionTO Update(SessionTO Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessionTO> GetByStudent(UserTO student)
        {
            throw new NotImplementedException();
        }
    }
}