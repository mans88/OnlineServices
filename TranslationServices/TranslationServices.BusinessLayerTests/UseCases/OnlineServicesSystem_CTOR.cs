//VERIFIED V3
using Moq;
using OnlineServices.Common.Exceptions;
using Serilog;
using System;
using TranslationServices.BusinessLayer.UseCases;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;
using Xunit;

namespace TranslationServices.BusinessLayerTests.UseCases
{
    public class OnlineServicesSystem_CTOR
    {
        [Fact]
        public void CTOR_ShouldInstaciate_WhenValidInjectionIsProvided()
        {
            var mockILogger = new Mock<ILogger>();
            var mockITRSTranslationService = new Mock<ITRSTranslationService>();

            var sut = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            
            Assert.NotNull(sut);
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void CTOR_ThrowLoggedNullException_WhenNullInjectionIsProvided()
        {
            ILogger iLogger = null;
            ITRSTranslationService iTRSTranslationService = null;

            var mockILogger = TestHelper.MakeILogger();
            LoggedException.Logger = mockILogger.Object;

            Assert.Throws<LoggedException>(() => new OnlineServicesSystem(iLogger, iTRSTranslationService));
            mockILogger.Verify(x => x.Error(It.IsAny<ArgumentNullException>(), It.IsAny<string>()), Times.Once);
            //TODO Times.Twice?
        }

        [Fact]
        public void CTOR_ThrowLoggedNullException_WhenNullILoggerIsProvided()
        {
            ILogger iLogger = null;
            var mockILogger = TestHelper.MakeILogger();
            LoggedException.Logger = mockILogger.Object;

            var mockITRSTranslationService = new Mock<ITRSTranslationService>();

            Assert.Throws<LoggedException>(() => new OnlineServicesSystem(iLogger, mockITRSTranslationService.Object));
            mockILogger.Verify(x => x.Error(It.IsAny<ArgumentNullException>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowLoggedNullException_WhenNullITRSTranslationServiceIsProvided()
        {
            var mockILogger = TestHelper.MakeILogger();
            LoggedException.Logger = mockILogger.Object;

            ITRSTranslationService iTRSTranslationService = null;

            Assert.Throws<LoggedException>(() => new OnlineServicesSystem(mockILogger.Object, iTRSTranslationService));
            mockILogger.Verify(x=>x.Error(It.IsAny<ArgumentNullException>(), It.IsAny<string>()), Times.Once);
        }
    }
}
