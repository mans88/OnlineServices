using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System.Linq;

namespace RegistrationServices.BusinessLayer.Extensions
{
    public static class SessionExtensions
    {
        public static Session ToDomain(this SessionTO session)
        {
            return  new Session
            {
                Id = session.Id,
                Course = session.Course.ToDomain(),
                Teacher = session.Teacher.ToDomain(),
                Attendees = session.Attendees?.Select(x => x.ToDomain()).ToList()
            };
        }

        public static SessionTO ToTransfertObject(this Session session)
        {
            return new SessionTO
            {
                Id = session.Id,
                Course = session.Course.ToTransfertObject(),
                //Local = session.Local
                Teacher  = session.Teacher.ToTransfertObject(),
                Attendees = session.Attendees?.Select(x=> x.ToTransfertObject()).ToList()
            };
        }
    }
}
