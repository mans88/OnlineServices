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
        public List<SessionTO> GetTodaySessions()
        {
            return new List<SessionTO> { };
        }
    }
}
