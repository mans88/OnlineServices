using OnlineServices.Common.FacilityServices.Interfaces;
using System;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAttendeeRole : IFSAttendeeRole
    {
        private readonly IFSUnitOfWork unitOfWork;

        public FSAttendeeRole(IFSUnitOfWork iFSUnitOfWork)
        {
            this.unitOfWork = iFSUnitOfWork ?? throw new ArgumentNullException(nameof(iFSUnitOfWork));
        }
    }
}
