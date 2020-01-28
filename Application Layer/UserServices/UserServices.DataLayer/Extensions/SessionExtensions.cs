using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationServices.DataLayer.Extensions
{
    public static class SessionExtensions
    {
        public static SessionTO ToTransfertObject(this SessionEF session)
        {
            return new SessionTO()
            {
                Id = session.Id,
                Teacher = session.UserSessions.FirstOrDefault(x => x.User.Role == UserRole.Teacher).User.ToTransfertObject(),
                Course = session.Course?.ToTransfertObject(),
                //SessionDays = session.Dates.Select(x => x.ToTransfertObject()).ToList(),

                Attendees = session.UserSessions.Where(x => x.User.Role == UserRole.Attendee).Select(x => x.User.ToTransfertObject()).ToList()
            };
        }

        public static SessionEF ToEF(this SessionTO session)
        {
            if (session is null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            var result = new SessionEF()
            {
                Id = session.Id,
                Course = session.Course.ToEF(),
                Dates = session.SessionDays?.Select(x => x.ToEF()).ToList()
            };

            if (session.Attendees == null)
            {
                return result;
            }

            result.UserSessions = new List<UserSessionEF>();

            foreach (var user in session.Attendees)
            {
                var userSession = new UserSessionEF()
                {
                    SessionId = session.Id,
                    Session = result,
                    UserId = user.Id,
                    User = user.ToEF()
                };
                result.UserSessions.Add(userSession);

                var teacherEF = new UserSessionEF()
                {
                    SessionId = session.Id,
                    Session = result,
                    UserId = session.Teacher.Id,
                    User = session.Teacher.ToEF()
                };

                result.UserSessions.Add(teacherEF);

                foreach (UserSessionEF item in result.UserSessions)
                {
                    item.User.UserSessions.Add(item);
                }
            }

            return result;
        }
    }
}