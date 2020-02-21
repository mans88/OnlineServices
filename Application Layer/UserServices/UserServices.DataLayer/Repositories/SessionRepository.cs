using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;
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
        {
            if (Id == 0)
                throw new ArgumentNullException();

            if (!registrationContext.Sessions.Any(x => x.Id == Id))
                throw new ArgumentException($"There is no  session at Id{Id}");

            return registrationContext.Sessions
            .AsNoTracking()
            .Include(x => x.UserSessions)
            .Include(x => x.Dates)
            .FirstOrDefault(x => x.Id == Id).ToTransfertObject();
        }

        public IEnumerable<DateTime> GetDates(SessionTO session)
            => registrationContext.Sessions
            .AsNoTracking()
            .SelectMany(x => x.Dates.Select(x => x.Date));

        public IEnumerable<UserTO> GetStudents(SessionTO session)
            => registrationContext.UserSessions
                .Where(x => x.User.Role == UserRole.Attendee)
                .Select(x => x.User.ToTransfertObject()).ToList();

        public bool Remove(SessionTO entity)
            => Remove(entity.Id)
;

        public bool Remove(int Id)
        {
            if (!registrationContext.Sessions.Any(x => x.Id == Id))
                throw new ArgumentException($"There is no session at Id {Id}");

            var sessionToDelete = registrationContext.Sessions.FirstOrDefault(x => x.Id == Id);

            try
            {
                registrationContext.Sessions.Remove(sessionToDelete);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public SessionTO Update(SessionTO Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessionTO> GetByUser(UserTO user)
        {
            if (user.Role == UserRole.Assistant)
                throw new ArgumentException("Assistant can not subscribe to sessions");

            var prout = GetAll();

            return GetAll().Where(x => (x.Attendees.Contains(user))
            || (x.Teacher.Id == user.Id));
        }

        public IEnumerable<SessionTO> GetSessionsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}