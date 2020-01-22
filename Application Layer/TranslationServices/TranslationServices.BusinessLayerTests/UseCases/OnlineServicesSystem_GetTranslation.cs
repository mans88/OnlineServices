using Moq;
using OnlineServices.Common.Enumerations;
using OnlineServices.Common.Exceptions;
using System;
using System.Linq;
using TranslationServices.BusinessLayer.UseCases;
using Xunit;

namespace TranslationServices.BusinessLayerTests.UseCases
{
    public class OnlineServicesSystem_GetTranslation
    {
        [Fact]
        public void GetTranslation_ShouldNotTranslateEnglish_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();
            LoggedException.Logger = mockILogger.Object;

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var EnglishTupleToTranslate = new Tuple<Language, string>(Language.English, "English Source String");

            //ACT
            var translated = translationUC.GetTranslations(TestHelper.FakeApiKey, EnglishTupleToTranslate);

            //ASSERT
            Assert.NotNull(translated);
            Assert.Equal(EnglishTupleToTranslate.Item2, translated.ToString(Language.English));
            Assert.Equal(TestHelper.FrenchTranslated, translated.ToString(Language.French));
            Assert.Equal(TestHelper.DutchTranslated, translated.ToString(Language.Dutch));
            mockITRSTranslationService.Verify(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()),
                Times.Once);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GetTranslation_ShouldNotTranslateFrench_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();
            LoggedException.Logger = mockILogger.Object;

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var FrenchTupleToTranslate = new Tuple<Language, string>(Language.French, "French Source String");

            //ACT
            var translated = translationUC.GetTranslations(TestHelper.FakeApiKey, FrenchTupleToTranslate);

            //ASSERT
            Assert.NotNull(translated);
            Assert.Equal(TestHelper.EnglishTranslated, translated.ToString(Language.English));
            Assert.Equal(FrenchTupleToTranslate.Item2, translated.ToString(Language.French));
            Assert.Equal(TestHelper.DutchTranslated, translated.ToString(Language.Dutch));
            mockITRSTranslationService.Verify(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()),
                Times.Once);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GetTranslation_ShouldNotTranslateDutch_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();
            LoggedException.Logger = mockILogger.Object;

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchTupleToTranslate = new Tuple<Language, string>(Language.Dutch, "Dutch Source String");

            //ACT
            var translated = translationUC.GetTranslations(TestHelper.FakeApiKey, DutchTupleToTranslate);

            //ASSERT
            Assert.NotNull(translated);
            Assert.Equal(TestHelper.EnglishTranslated, translated.ToString(Language.English));
            Assert.Equal(TestHelper.FrenchTranslated, translated.ToString(Language.French));
            Assert.Equal(DutchTupleToTranslate.Item2, translated.ToString(Language.Dutch));
            mockITRSTranslationService.Verify(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()),
                Times.Once);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenAPIKeyIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();
            LoggedException.Logger = mockILogger.Object;

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchTupleToTranslate = new Tuple<Language, string>(Language.Dutch, "Dutch Source String");

            //ACT & ASSERT
            Assert.Throws<NecessaryDataException>(() => translationUC.GetTranslations(null, DutchTupleToTranslate));
            mockITRSTranslationService.Verify(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenMultiLanguageStringIsNULL()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();
            LoggedException.Logger = mockILogger.Object;

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var TupleToTranslate = new Tuple<Language, string>(Language.French, null);

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.GetTranslations(TestHelper.FakeApiKey, TupleToTranslate));
            mockITRSTranslationService.Verify(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenSourceStringToTranslateIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();
            LoggedException.Logger = mockILogger.Object;

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var TupleToTranslate = new Tuple<Language, string>(Language.Dutch, "  ");

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.GetTranslations(TestHelper.FakeApiKey, TupleToTranslate));
            mockITRSTranslationService.Verify(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenLanguageIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();
            LoggedException.Logger = mockILogger.Object;

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var TupleToTranslate = new Tuple<Language, string>((Language)50, "Dutch Source String");

            //ACT & ASSERT
            Assert.Throws<LanguageNotSupportedException>(() => translationUC.GetTranslations(TestHelper.FakeApiKey, TupleToTranslate));
            mockITRSTranslationService.Verify(x => x.TranslateAsync(It.IsAny<Tuple<Language, string>>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
