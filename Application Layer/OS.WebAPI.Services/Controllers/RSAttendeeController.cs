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

        [HttpGet("{userId}")]
        public IActionResult GetTodaySession(int userId)
        {
            return new JsonResult(iRSAttendeeRole.GetTodaySession(userId));
        }

        [HttpGet("{email}")]
        public IActionResult GetIdByMail(string email)
        {
            return new JsonResult(iRSAttendeeRole.GetIdByMail(email));
        }
    }
}
