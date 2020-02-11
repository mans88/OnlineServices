using System;
using System.Collections.Generic;
using System.Text;

namespace OS.AttendanceServices.BusinessLayer.Domain
{
    public class AttendeePresence
    {
        public int AttendeeId { get; set; }
        public int SessionId { get; set; }
        public List<DateTime> PresenceDay { get; set; }
    }
}
