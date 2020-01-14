using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceServices.BusinessLayer.Domain
{
    public class AttendeePresence
    {
        public int attendeeID;
        public int formationID;
        public List<DateTime> PresenceDay;
    }
}
