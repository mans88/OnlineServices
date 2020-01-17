using OnlineServices.Common.FacilityServices.Interfaces;
using System;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole : IFSAttendeeRole
    {
        private readonly IFSUnitOfWork unitOfWork;

        public AttendeeRole(IFSUnitOfWork iFSUnitOfWork)
        {
            this.unitOfWork = iFSUnitOfWork ?? throw new ArgumentNullException(nameof(iFSUnitOfWork));
        }
    }
}
