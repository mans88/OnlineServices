using OnlineServices.Common.RegistrationServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        private readonly IPresenceRepository presenceRepository;
        private readonly IRSServiceRole userServices;

        public AttendeeRole(IPresenceRepository presenceRepository, IRSServiceRole userServices)
        {
            this.presenceRepository = presenceRepository ?? throw new ArgumentNullException(nameof(presenceRepository));
            this.userServices = userServices;
        }
    }
}
