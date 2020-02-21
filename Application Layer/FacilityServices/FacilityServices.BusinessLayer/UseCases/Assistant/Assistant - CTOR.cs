using OnlineServices.Common.FacilityServices.Interfaces;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAssistantRole : FSAttendeeRole, IFSAssistantRole
    {
        private readonly IFSUnitOfWork unitOfWork;

        public FSAssistantRole(IFSUnitOfWork iFSUnitOfWork) : base(iFSUnitOfWork)
        {
            this.unitOfWork = iFSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iFSUnitOfWork));
        }
    }
}