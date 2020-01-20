using OnlineServices.Common.MealServices;
using OnlineServices.Common.MealServices.Interfaces;
using System;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class MSAttendeeRole : IMSAttendeeRole
    {
        private readonly IMSUnitOfWork iMSUnitOfWork;

        public MSAttendeeRole(IMSUnitOfWork iMSUnitOfWork)
        {
            this.iMSUnitOfWork = iMSUnitOfWork ?? throw new ArgumentNullException(nameof(iMSUnitOfWork));
        }
    }
}
