using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.RegistrationServices.Enumerations;

using System;

namespace OnlineServices.Common.RegistrationServices.TransferObject
{
    public class SessionDayTO : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime DaySession { get; set; }
        public SessionPresenceType PresenceType { get; set; }
    }
}
