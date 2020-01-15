using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceServices.BusinessLayer.Domain
{
    public class AttendeePresence
    {
        public int AttendeeId { get; set; }
        public int SessionId { get; set; }
        public List<DateTime> PresenceDay { get; set; } = new List<DateTime>();
    }
}
