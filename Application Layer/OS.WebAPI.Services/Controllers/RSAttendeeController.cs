using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceServices.BusinessLayer.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineServices.Common.AttendanceServices;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace OS.WebAPI.Services.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RSAttendeeController : ControllerBase
    {
        private readonly ILogger<RSAttendeeController> _logger;
        private readonly IRSAttendeeRole iRSAttendeeRole;

        public RSAttendeeController(ILogger<RSAttendeeController> logger, IRSAttendeeRole iRSAttendeeRole)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.iRSAttendeeRole = iRSAttendeeRole ?? throw new ArgumentNullException(nameof(iRSAttendeeRole));
        }

        [HttpGet]
        public SessionTO GetTodaySession(int userId)
        {
            return iRSAttendeeRole.GetTodaySession(userId);
        }

        [HttpGet]
        public int GetIdByMail(string email)
        {
            return iRSAttendeeRole.GetIdByMail(email);
        }
    }
}
