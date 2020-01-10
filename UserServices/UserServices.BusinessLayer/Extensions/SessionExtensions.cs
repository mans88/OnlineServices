using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System.Linq;

namespace RegistrationServices.BusinessLayer.Extensions
{
    public static class SessionExtensions
    {
        public static Session ToDomain(this SessionTO sessionTO)
        {
            return  new Session
            {
                Id = sessionTO.Id,
                Course = sessionTO.Course.ToDomain(),
                Teacher = sessionTO.TeacherName.ToDomain(),
                Attendees = sessionTO.Attendees?.Select(x => x.ToDomain()).ToList()
            };
        }

        public static SessionTO ToTransferObject(this Session session)
        {
            return new SessionTO
            {
                Id = session.Id,
                Course = session.Course.ToTransferObject(),
                //Local = session.Local
                TeacherName  = session.Teacher.ToTransferObject(),
                Attendees = session.Attendees?.Select(x=> x.ToTransferObject()).ToList()
            };
        }
    }
}
