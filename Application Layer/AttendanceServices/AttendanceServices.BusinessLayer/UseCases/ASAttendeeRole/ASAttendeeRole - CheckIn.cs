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
        public bool CheckIn(int sessionId, int attendeeId)
        {
            if (!userServices.GetSessionAttendes(sessionId).Any(x => x.Id == attendeeId))
                throw new Exception("Attendee do not exist in formation");
            if (!userServices.GetSession(sessionId).SessionDays.Any(x => x.Date.IsSameDate(DateTime.Now)))
                throw new Exception("Not a formation day");
            try
            {
                var presence = new AttendeePresenceTO
                {
                    SessionId = sessionId,
                    AttendeeId = attendeeId,
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
    }
}
