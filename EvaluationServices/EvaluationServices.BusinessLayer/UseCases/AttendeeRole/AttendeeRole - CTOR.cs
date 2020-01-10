using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole : IESAttendeeRole
    {
        private readonly IRepository<FormTO, int> questionRepository;
        private readonly IUserServiceTemp userService;

        public AttendeeRole(IRepository<FormTO, int> questionRepository, IUserServiceTemp userService)
        {
            this.questionRepository = questionRepository;
            this.userService = userService;
        }
    }
}
