//VERIFIED V3
using Moq;
using OnlineServices.Common.Enumerations;
using OnlineServices.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class AzureCognitiveAgent_TranslateAsyncTests
    {
        public static IEnumerable<object[]> Data
            => new List<object[]>
                {
                    new object[] { new Tuple<Language,string>(Language.English, "The rough sea makes him nauseous."), new Tuple<Language, string>(Language.French, "La mer agitée le rend nauséeux.") },
                    new object[] { new Tuple<Language,string>(Language.English, "Do you see that man there in that photo?"), new Tuple<Language, string>(Language.Dutch, "Zie je die man daar op die foto?") },
                    new object[] { new Tuple<Language,string>(Language.French, "Maman, donne-moi un peu de lait, s'il te plaît."), new Tuple<Language, string>(Language.English, "Mommy, please give me some milk.") },
                    new object[] { new Tuple<Language,string>(Language.French, "Jouer au papa et à la maman."), new Tuple<Language, string>(Language.Dutch, "Het spelen van mama en papa.") },
                    new object[] { new Tuple<Language,string>(Language.Dutch, "Dat is niet eerlijk!"), new Tuple<Language, string>(Language.English, "That's not fair!") },
                    new object[] { new Tuple<Language,string>(Language.Dutch, "Ga je met me mee, mis?"), new Tuple<Language, string>(Language.French, "Tu viens avec moi, mademoiselle ?") },
                };

        [Theory]//(Skip = "Integration Test, enable when doing integration test.")]
        [MemberData(nameof(Data))]
        public async Task TranslateAsync_ShouldTranslate_WhenValidSentenceIsProvided(Tuple<Language, string> StringToTranslate, Tuple<Language, string> StringTranlated)
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            ITRSTranslationService TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);

            //ACT
            var TranslatedSentence = await TranslatorToTest.TranslateAsync(StringToTranslate);

            //ASSERT
            Console.WriteLine($"Original: {StringToTranslate}");
            Assert.Contains(TranslatedSentence, x => x.Item1 == StringTranlated.Item1);
            Assert.Equal(StringTranlated, TranslatedSentence.First(x => x.Item1 == StringTranlated.Item1));


            //TO DO VERIFY OTHERS CTORS!
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task TranslateAsync_ThrowsArgumentNullException_WhenTuppleToTranslateIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            ITRSTranslationService TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);

            Tuple<Language, string> args =null;

            //ACT & ASSERT
            await Assert.ThrowsAsync<LoggedException>(async () => await TranslatorToTest.TranslateAsync(args));
            mockILogger.Verify(x => x.Error(It.IsAny< ArgumentNullException>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task TranslateAsync_ThrowsArgumentNullException_WhenStringToTranslateIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            ITRSTranslationService TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);

            var args = new Tuple<Language, string>(Language.Dutch, null);

            //ACT & ASSERT
            await Assert.ThrowsAsync<IsNullOrWhiteSpaceException>(async () => await TranslatorToTest.TranslateAsync(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task TranslateAsync_ThrowsArgumentNullException_WhenStringToTranslateIsEmpty()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            ITRSTranslationService TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new Tuple<Language, string>(Language.English, "");

            //ACT & ASSERT
            await Assert.ThrowsAsync<IsNullOrWhiteSpaceException>(async () => await TranslatorToTest.TranslateAsync(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task TranslateAsync_ThrowsArgumentNullException_WhenStringToTranslateIsWhiteSpace()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            ITRSTranslationService TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new Tuple<Language, string>(Language.French, "   ");

            //ACT & ASSERT
            await Assert.ThrowsAsync<IsNullOrWhiteSpaceException>(async () => await TranslatorToTest.TranslateAsync(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task TranslateAsync_ThrowsArgumentOutOfRange_WhenFromLangueIsNotDefinedInEnum()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            ITRSTranslationService TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new Tuple<Language, string>((Language)50, "こんにちは");

            //ACT & ASSERT
            await Assert.ThrowsAsync<LanguageNotSupportedException>(async () => await TranslatorToTest.TranslateAsync(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
