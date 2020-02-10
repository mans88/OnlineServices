using OnlineServices.Common.DataAccessHelpers;

using System;
using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices.TransfertObjects
{
    public class CheckInTO : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int SessionId { get; set; }
        public int AttendeeId { get; set; }
        public DateTime CheckInTime { get; set; }
    }
}
