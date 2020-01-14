using OnlineServices.Common.FacilityServices.Interfaces;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole : AttendeeRole, IFSAssistantRole
    {
        private readonly IFSUnitOfWork unitOfWork;

        public AssistantRole(IFSUnitOfWork iFSUnitOfWork) : base(iFSUnitOfWork)
        {
            this.unitOfWork = iFSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iFSUnitOfWork));
        }
    }
}