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
                Teacher = session.Teacher?.ToTransfertObject(),
                Course = session.Course.ToTransfertObject(),
                Dates = session.Dates,
                //Attendees = session.UserSessions.Select(x => x.User.ToTransfertObject()).ToList()

                Attendees = session.UserSessions
                .Where(x => x.User.Role == UserRole.Attendee)
                .Select(x => x.User.ToTransfertObject()).ToList()
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
                Teacher = session?.Teacher.ToEF(),
                Course = session.Course.ToEF(),
                Dates = session.Dates
            };

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
            }

            if (session.Teacher != null)
            {
                var teacherEF = new UserSessionEF()
                {
                    SessionId = session.Id,
                    Session = result,
                    UserId = session.Teacher.Id,
                    User = session.Teacher.ToEF()
                };

                result.UserSessions.Add(teacherEF);
            }

            return result;
        }
    }
}