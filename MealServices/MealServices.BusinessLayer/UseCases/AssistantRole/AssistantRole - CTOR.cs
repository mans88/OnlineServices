using OnlineServices.Common.MealServices;
using OnlineServices.Common.MealServices.Interfaces;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class AssistantRole : AttendeeRole, IMSAssistantRole
    {
        private readonly IMSUnitOfWork iMSUnitOfWork;

        public AssistantRole(IMSUnitOfWork iMSUnitOfWork) : base(iMSUnitOfWork)
        {
            this.iMSUnitOfWork = iMSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iMSUnitOfWork));
        }
    }
}
