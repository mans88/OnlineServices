//VERIFIED V3
using Moq;
using OnlineServices.Common.Exceptions;
using System;
using Xunit;
using Serilog;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using TranslationServices.DataLayer.ServiceAgents.Domain;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class AzureCognitiveAgent_CTORTests
    {
        #region Serilog.ILogger
        [Fact]
        public void CTOR_ThrowsLoggedExceptionNullException_WhenIloggerIsNull()
        {
            //ARRANGE
            ILogger iLogger = null;
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            AzureCognitiveArgs AzArg = TestHelper.AzCognitiveArgs;

            //ACT & ASSERT
            Assert.Throws<LoggedException>(() => new AzureCognitiveAgent(iLogger, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<ArgumentNullException>(), It.IsAny<string>()), Times.Once);
        }
        #endregion Serilog.ILogger

        #region AzureCognitiveArgs
        [Fact]
        public void CTOR_ThrowsLoggedNullException_WhenAzureCognitiveArgsIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;
            AzureCognitiveArgs AzArg = null;

            //ACT & ASSERT
            Assert.Throws<LoggedException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<ArgumentNullException>(), It.IsAny<string>()), Times.Once);
        }
        #endregion AzureCognitiveArgs
    }
}
