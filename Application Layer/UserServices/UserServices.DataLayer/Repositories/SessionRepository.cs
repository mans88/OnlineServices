using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationServices.DataLayer.Repositories
{
    public class SessionRepository : IRSSessionRepository
    {
        private RegistrationContext registrationContext;

        public SessionRepository(RegistrationContext registrationContext)
        {
            this.registrationContext = registrationContext;
        }

        public SessionTO Add(SessionTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            if (Entity.Id != 0)
            {
                return Entity;
            }

            var sessionEF = Entity.ToEF();
            sessionEF.Course = registrationContext.Courses.First(x => x.Id == Entity.Course.Id);

            //By Amb
            //sessionEF.
            //By Amb

            registrationContext.Sessions.Add(sessionEF);
            return sessionEF.ToTransfertObject();
            // => registrationContext.Add(Entity.ToEF()).Entity.ToTransfertObject();
        }

        public IEnumerable<SessionTO> GetAll()
            => registrationContext.Sessions
                .AsNoTracking()
                .Include(x => x.UserSessions).ThenInclude(x => x.User)
                .Include(x => x.Dates)
                .Select(x => x.ToTransfertObject())
                .ToList();

        public SessionTO GetById(int Id)
            => registrationContext.Sessions
                .AsNoTracking()
                .Include(x => x.UserSessions)
                .Include(x => x.Dates)
                .FirstOrDefault(x => x.Id == Id).ToTransfertObject();

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

        public IEnumerable<SessionTO> GetByUser(UserTO user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessionTO> GetSessionsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}