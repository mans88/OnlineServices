using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceServices.BusinessLayer.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineServices.Common.AttendanceServices;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace OS.WebAPI.Services.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ASAttendeeController : ControllerBase
    {
        private readonly ILogger<ASAttendeeController> _logger;
        private readonly IASAttendeeRole iASAttendeeRole;

        public ASAttendeeController(ILogger<ASAttendeeController> logger, IASAttendeeRole iASAttendeeRole)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.iASAttendeeRole = iASAttendeeRole ?? throw new ArgumentNullException(nameof(iASAttendeeRole));
        }

        [HttpGet]
        public ActionResult<bool> CheckIn(int sessionId, int attendeeId)
        {
            var checkInArgs = new CheckInTO
            {
                SessionId = sessionId,
                AttendeeId = attendeeId,
                CheckInTime = DateTime.Now
            };

            try
            {
                if (iASAttendeeRole.CheckIn(checkInArgs))
                    return Ok(true);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }
    }
}
