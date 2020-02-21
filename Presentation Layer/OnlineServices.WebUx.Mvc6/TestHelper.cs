using Microsoft.Extensions.Logging;
using Moq;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.WebUx.Mvc6.Controllers;
using Serilog;
using System;

namespace OnlineServices.WebUx.Mvc6
{
    public static class TestHelper
    {
        public static IRSServiceRole MockIRSServiceRole()
        {
            // REVIEW ILogger a;

            var mockILogger = new Mock<IRSServiceRole>();

           // mockILogger.Setup(x => x.);

            return mockILogger.Object;
        }
    }
}
