//VERIFIED V3
using Google.Cloud.Translation.V2;
using OnlineServices.Common.Exceptions;

using Language = OnlineServices.Common.Enumerations.Language;

namespace TranslationServices.DataLayer.ServiceAgents.Extensions
{
    public static class LanguageExtensions
    {
        public static string ToAzureLanguage(this Language language)
        {
            string languageCode;
            switch (language)
            {
                case Language.English:
                    languageCode = "en";
                    break;
                case Language.French:
                    languageCode = "fr";
                    break;
                case Language.Dutch:
                    languageCode = "nl";
                    break;
                default:
                    throw new LanguageNotSupportedException("LanguageNotSupportedException. ToAzureCognitiveLanguage(this Language) @ LanguageExtensions.");
            }

            return languageCode;
        }

        public static Language ToLanguage(this string language)
        {
            Language languageCode;
            switch (language)
            {
                case "en":
                    languageCode = Language.English;
                    break;
                case "fr":
                    languageCode = Language.French;
                    break;
                case "nl":
                    languageCode = Language.Dutch;
                    break;
                default:
                    throw new LanguageNotSupportedException("LanguageNotSupportedException. ToLanguage(this string) @ LanguageExtensions.");
            }

            return languageCode;
        }

        public static string ToGoogleLanguage(this Language language)
        {
            string languageCode;
            switch (language)
            {
                case Language.English:
                    languageCode = LanguageCodes.English;
                    break;
                case Language.French:
                    languageCode = LanguageCodes.French;
                    break;
                case Language.Dutch:
                    languageCode = LanguageCodes.Dutch;
                    break;
                default:
                    throw new LanguageNotSupportedException("LanguageNotSupportedException. ToGoogleLanguage(this Language) @ LanguageExtensions.");
            }

            return languageCode;
        }
    }
}
