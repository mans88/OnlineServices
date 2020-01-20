using OnlineServices.Common.RegistrationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceServices.BusinessLayer.UseCases
{
    public partial class ASAttendeeRole
    {
        private readonly IPresenceRepository presenceRepository;
        private readonly IRSServiceRole userServices;

        public ASAttendeeRole(IPresenceRepository presenceRepository, IRSServiceRole userServices)
        {
            this.presenceRepository = presenceRepository ?? throw new ArgumentNullException(nameof(presenceRepository));
            this.userServices = userServices;
        }
    }
}
