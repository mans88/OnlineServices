//VERIFIED V3
using Moq;
using Serilog;
using System;
using TranslationServices.DataLayer.ServiceAgents.Domain;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public static class TestHelper
    {
        public static string GoogleAPIKey()
        {
            return @"C:\TFS\OnlineServices-d9921f8e5f21.json";
        }

        public static AzureCognitiveArgs AzCognitiveArgs
            => new AzureCognitiveArgs(SubscriptionKey: "66b23505dc864928a25661c03ba0c7b0", Endpoint: @"https://api.cognitive.microsofttranslator.com/translate?api-version=3.0");

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
