using OnlineServices.Common.DataAccessHelpers;

using System;
using System.Collections.Generic;

namespace OnlineServices.Common.AttendanceServices.TransfertObjects
{
    public class AttendeePresenceTO : IEntity<int>
    {
        public int Id { get; set; }
        public int AttendeeID { get; set; }
        public int SessionID { get; set; }
        public int LocalID { get; set; }
        public List<DateTime> PresenceDay { get; set; }
    }
}
