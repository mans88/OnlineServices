//VERIFIED V3
using Moq;
using OnlineServices.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgentsTests;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgents.DomainTests
{
    public class AzureCognitiveArgsTests
    {
        [Fact]
        public void CTORWithParameter_ShoulInstanciate_WhenCalled()
        {
            var sut = new AzureCognitiveArgs(SubscriptionKey: "SubscriptionKey", Endpoint: "Endpoint");

            Assert.Equal("SubscriptionKey", sut.SubscriptionKey);
            Assert.Equal("Endpoint", sut.Endpoint);
        }

        [Fact]
        public void CTOR_ThrowsArgumentNullException_WhenAzArgSubscriptionKeyIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveArgs(SubscriptionKey: null, Endpoint: "Endpoint"));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenAzArgSubscriptionKeyIsEmpty()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveArgs(SubscriptionKey: "", Endpoint: "Endpoint"));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenSubscriptionKeyIsWhitSpace()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveArgs(SubscriptionKey: "   ", Endpoint: "Endpoint"));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsArgumentNullException_WhenAzArgEndpointIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveArgs(SubscriptionKey: "SubscriptionKey", Endpoint: null));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenAzArgEndpointIsEmpty()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveArgs(SubscriptionKey: "SubscriptionKey", Endpoint: ""));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenEndpointIsWhitSpace()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveArgs(SubscriptionKey: "SubscriptionKey", Endpoint: "   "));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
