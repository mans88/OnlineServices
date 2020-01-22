using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System;

namespace OnlineServices.CommonTests
{
    public static class TestHelper
    {
        public static Mock<ILogger> MockILogger()
        {
            var mockILogger = new Mock<ILogger>();

            mockILogger.Setup(x => x.Error(It.IsAny<string>()));
            mockILogger.Setup(x => x.Error(It.IsAny<Exception>(), It.IsAny<string>()));
            mockILogger.Setup(x => x.Error(It.IsAny<ArgumentNullException>(), It.IsAny<string>()));
            mockILogger.Setup(x => x.Error(It.IsAny<ArgumentOutOfRangeException>(), It.IsAny<string>()));

            return mockILogger;
        }
    }
}
