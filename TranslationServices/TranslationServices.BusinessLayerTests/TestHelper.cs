using Moq;
using OnlineServices.Common.Enumerations;
using OnlineServices.Common.SecurityServices.TransfertObjects;
using Serilog;
using System;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

namespace TranslationServices.BusinessLayerTests
{
    public static class TestHelper
    {
        public const string EnglishTranslated = "EnglishTranslated";
        public const string FrenchTranslated = "FrenchTranslated";
        public const string DutchTranslated = "DutchTranslated";
        public static Tuple<Language, string>[] TranslatedV3 = new Tuple<Language, string>[]
        {
            new Tuple<Language,string>(Language.English, EnglishTranslated),
            new Tuple<Language,string>(Language.French, FrenchTranslated),
            new Tuple<Language,string>(Language.Dutch, DutchTranslated),
        };

        //public static Mock<ITRSTranslationServiceV1> MakeITRSTranslationServiceV1()
        //{
        //    var mockITRSTranslationService = new Mock<ITRSTranslationServiceV1>();

        //    mockITRSTranslationService
        //        .Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), Language.English))
        //        .Returns(EnglishTranslated);

        //    mockITRSTranslationService
        //        .Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), Language.French))
        //        .Returns(FrenchTranslated);

        //    mockITRSTranslationService
        //        .Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), Language.Dutch))
        //        .Returns(DutchTranslated);

        //    return mockITRSTranslationService;
        //}

        public static ServiceAuthorization FakeApiKey
            = new ServiceAuthorization
            {
                AuthorizationToken = Guid.NewGuid(),
                ServiceGuid = Guid.NewGuid(),
                TimeStamp = DateTimeOffset.Now
            };

        public static Mock<ITRSTranslationService> MakeITRSTranslationService()
        {
            var mockITRSTranslationService = new Mock<ITRSTranslationService>();

            mockITRSTranslationService
                .Setup(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()))
                .Returns(Task.FromResult(TranslatedV3));

            return mockITRSTranslationService;
            //TODO Diferents 'returns' selon languages...
        }

        public static Mock<ILogger> MakeILogger()
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
