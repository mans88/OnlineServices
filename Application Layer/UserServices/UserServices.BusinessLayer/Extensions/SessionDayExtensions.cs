using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.BusinessLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationServices.BusinessLayer.Extensions
{
    public static class SessionDayExtensions
    {
        public static SessionDayTO ToTransfertObject(SessionDay sessionDay)
        {
            if (sessionDay == null)
                throw new ArgumentNullException(nameof(sessionDay));

            return new SessionDayTO
            {
                Id = sessionDay.Id,
                Date = sessionDay.Date,
                PresenceType = sessionDay.PresenceType
            };
        }

        public static SessionDay ToDomain(SessionDayTO sessionDay)
        {
            if (sessionDay == null)
                throw new ArgumentNullException(nameof(sessionDay));

            return new SessionDay
            {
                Id = sessionDay.Id,
                Date = sessionDay.Date,
                PresenceType = sessionDay.PresenceType
            };
        }
    }
}