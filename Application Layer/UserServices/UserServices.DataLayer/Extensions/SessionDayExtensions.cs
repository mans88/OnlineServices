using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RegistrationServices.DataLayer.Extensions
{
    public static class SessionDayExtensions
    {
        public static SessionDayTO ToTransfertObject(this SessionDayEF sessionDay)
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

        public static SessionDayEF ToEF(this SessionDayTO sessionDay)
        {
            if (sessionDay == null)
                throw new ArgumentNullException(nameof(sessionDay));

            return new SessionDayEF
            {
                Id = sessionDay.Id,
                Date = sessionDay.Date,
                PresenceType = sessionDay.PresenceType
            };
        }
    }
}