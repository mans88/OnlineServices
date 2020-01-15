using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.BusinessLayer.UseCases
{
    public partial class ESAttendeeRole : IESAttendeeRole
    {
        private readonly IESUnitOfWork iESUnitOfWork;
        
        private readonly IUserServiceTemp userService;

        public ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IUserServiceTemp userService)
        {
            this.iESUnitOfWork = iESUnitOfWork?? throw new ArgumentException(nameof(iESUnitOfWork));

            this.userService = userService;
        }
    }
}
