using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.RegistrationServices.Interface;
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
        private RegistrationServicesContext sessionContext;

        public SessionRepository(RegistrationServicesContext RSContext)
        {
            this.sessionContext = RSContext;
        }

        public SessionTO Add(SessionTO Entity)
            => sessionContext.Add(Entity.ToEF()).Entity.ToTransfertObject();

        public IEnumerable<SessionTO> GetAll()
            => sessionContext.Sessions
                .AsNoTracking()
                .Include(x => x.UserSessions)
                .Include(x => x.Dates)
                .Include(x => x.Teacher)
                .Select(x => x.ToTransfertObject())
                .ToList();

        public SessionTO GetById(int Id)
            => sessionContext.Sessions
                .AsNoTracking()
                .Include(x => x.UserSessions)
                .Include(x => x.Dates)
                .Include(x => x.Teacher)
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
    }
}