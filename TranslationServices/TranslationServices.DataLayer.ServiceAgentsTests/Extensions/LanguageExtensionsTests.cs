//VERIFIED V3
using OnlineServices.Common.Enumerations;
using OnlineServices.Common.Exceptions;
using TranslationServices.DataLayer.ServiceAgents.Extensions;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgents.ExtensionsTests
{
    public class LanguageExtensionsTests
    {
        [Theory]
        [InlineData("en", Language.English)]
        [InlineData("fr", Language.French)]
        [InlineData("nl", Language.Dutch)]
        public void ToLanguage_RenturnsLanguage_When2LettersLanguageIsProvided(string LanguageEnumToConvert, Language ExpectedLanguageCode)
        {
            var ActualLanguageCode = LanguageEnumToConvert.ToLanguage();

            Assert.Equal(ExpectedLanguageCode, ActualLanguageCode);
        }

        [Fact]
        public void ToLanguage_ThrowsLanguageNotSupported_WhenInvalid2LetterLanguageIsProvided()
        {
            var LanguageEnumToConvert = "zz";

            Assert.Throws<LanguageNotSupportedException>(() => LanguageEnumToConvert.ToLanguage());
        }

        [Theory]
        [InlineData(Language.English, "en")]
        [InlineData(Language.French, "fr")]
        [InlineData(Language.Dutch, "nl")]
        public void ToGoogleLanguage_Renturns2LettersLanguage_WhenLanguageEnumIsProvided(Language LanguageEnumToConvert, string ExpectedLanguageCode)
        {
            var ActualLanguageCode = LanguageEnumToConvert.ToGoogleLanguage();

            Assert.Equal(ExpectedLanguageCode, ActualLanguageCode);
        }

        [Fact]
        public void ToGoogleLanguage_ThrowsLanguageNotSupported_WhenInvalidLanguageIsProvided()
        {
            var LanguageEnumToConvert = (Language)50;

            Assert.Throws<LanguageNotSupportedException>(()=> LanguageEnumToConvert.ToGoogleLanguage());
        }

        [Theory]
        [InlineData(Language.English, "en")]
        [InlineData(Language.French, "fr")]
        [InlineData(Language.Dutch, "nl")]
        public void ToAzureLanguage_Renturns2LettersLanguage_WhenLanguageEnumIsProvided(Language LanguageEnumToConvert, string ExpectedLanguageCode)
        {
            var ActualLanguageCode = LanguageEnumToConvert.ToAzureLanguage();

            Assert.Equal(ExpectedLanguageCode, ActualLanguageCode);
        }

        [Fact]
        public void ToAzureLanguage_ThrowsLanguageNotSupported_WhenInvalidLanguageIsProvided()
        {
            var LanguageEnumToConvert = (Language)50;

            Assert.Throws<LanguageNotSupportedException>(() => LanguageEnumToConvert.ToAzureLanguage());
        }
    }
}
