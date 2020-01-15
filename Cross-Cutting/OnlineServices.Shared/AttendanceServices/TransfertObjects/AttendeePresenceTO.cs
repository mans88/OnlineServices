using OnlineServices.Common.DataAccessHelpers;

using System;
using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices.TransfertObjects
{
    public class AttendeePresenceTO : IEntity<int>
    {
        public int Id { get; set; }
        public int AttendeeId { get; set; }
        public int SessionId { get; set; }
        public int LocalId { get; set; } // REVIEW a revoir si necessaire
        public List<DateTime> PresenceDay { get; set; } = new List<DateTime>();
    }
}
