using OnlineServices.Common.AttendanceServices.Interfaces;
using OnlineServices.Common.RegistrationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.AttendanceServices.BusinessLayer.UseCases
{
    public partial class ASAttendeeRole
    {
        private readonly ICheckInRepository checkInRepository;
        private readonly IRSServiceRole userServices;

        public ASAttendeeRole(ICheckInRepository checkInRepository, IRSServiceRole userServices)
        {
            this.checkInRepository = checkInRepository ?? throw new ArgumentNullException(nameof(checkInRepository));
            this.userServices = userServices;
        }
    }
}
