using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.RegistrationServices.Enumerations;

using System;

namespace OnlineServices.Common.RegistrationServices.TransferObject
{
    public class SessionDayTO : IEntity<int>
    {
        public int Id { get; set; }
        DateTime DaySession { get; set}
        SessionPresenceType PresenceType { get; set; }
    }
}
