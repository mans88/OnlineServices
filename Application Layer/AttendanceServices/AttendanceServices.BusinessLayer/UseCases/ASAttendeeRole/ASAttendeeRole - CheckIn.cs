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
        public bool CheckIn(CheckInTO checkInArgs)
        {
            if (checkInArgs is null)
                throw new ArgumentNullException(nameof(checkInArgs));

            if (!userServices.GetSessionAttendes(checkInArgs.SessionId).Any(x => x.Id == checkInArgs.AttendeeId))
                throw new Exception("Attendee do not exist in formation");
            if (!userServices.GetSession(checkInArgs.SessionId).SessionDays.Any(x => x.Date.IsSameDate(DateTime.Now)))
                throw new Exception("This session is not held today.");
            if (!checkInArgs.CheckInTime.IsSameDate(DateTime.Now))
                throw new Exception("Attendee is not allowed to check-in other day than the current one.");

            try
            {
                checkInArgs.CheckInTime = DateTime.Now;
                var added = checkInRepository.Add(checkInArgs);
                if (added.Id == Guid.Empty)
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
