using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.WebUx.Mvc6.Controllers;
using Serilog;
using System;

namespace OnlineServices.WebUx.Mvc6Tests
{
    public static class TestHelper
    {
        public static Mock<ILogger<HomeController>> MockILogger()
        {
            ILogger a;
            a.
            var mockILogger = new Mock<ILogger<HomeController>>();

            mockILogger.Setup(x => x.LogError(It.IsAny<string>()));
            mockILogger.Setup(x => x.LogError(It.IsAny<Exception>(), It.IsAny<string>()));
            mockILogger.Setup(x => x.LogError(It.IsAny<ArgumentNullException>(), It.IsAny<string>()));
            mockILogger.Setup(x => x.LogError(It.IsAny<ArgumentOutOfRangeException>(), It.IsAny<string>()));

            return mockILogger;
        }
    }
}
