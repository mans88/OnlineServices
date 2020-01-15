using AttendanceServices.BusinessLayer.Domain;
using OnlineServices.Common.AttendanceServices;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceServices.BusinessLayer.UseCases
{
    public partial class ASAttendeeRole : IASAttendeeRole
    {
        public bool SetPresence(int sessionID, int attendeeID)
        {
            if(!userServices.GetSessionAttendes(sessionID).Any(x=> x == attendeeID))
                throw new Exception("Attendee do not exist in formation");
            if (!userServices.GetSession(sessionID).Days.Any(x => x.IsSameDate(DateTime.Now)))
                throw new Exception("Not a formation day");
            try
            {


                var presence = new AttendeePresenceTO
                {
                    SessionId = sessionID,
                    AttendeeId = attendeeID, 
                    PresenceDay = new List<DateTime> { DateTime.Now }
                };

                if (presenceRepository.Add(presence).Id <= 0)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return true;
        }
        public List<SessionTO> GetTodaySessions()
        {
            return new List<SessionTO> { };
        }
    }
}
