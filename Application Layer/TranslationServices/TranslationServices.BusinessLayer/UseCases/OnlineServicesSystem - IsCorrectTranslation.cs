//VERIFIED V3
using OnlineServices.Common.Enumerations;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.SecurityServices.Extensions;
using OnlineServices.Common.SecurityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.Extensions;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem
    {
        public bool IsCorrectTranslation(ServiceAuthorization APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage)
        {
            //CHECKS
            APIKey.IsWellFormed($"API Key is necessary for the translation service to work. {nameof(APIKey)} @ OnlineServicesSystem.IsCorrectTranslation");
            
            if (!Enum.IsDefined(typeof(Language), SourceLanguage))
                throw new LoggedException(new ArgumentOutOfRangeException($"IsCorrectTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}  @ OnlineServicesSystem.IsCorrectTranslation"));

            if (MLSToCheck is null)
                throw new LoggedException(new ArgumentNullException($"MLSToCorrect should not be null. {nameof(SourceLanguage)}is null @ OnlineServicesSystem.IsCorrectTranslation"));

            MLSToCheck.ToTupleLanguage(SourceLanguage).IsValidWithThrow();

            //LOGIC HERE
            var IsCorrect = true;
            var newTranslatorTask = Translator.TranslateAsync(MLSToCheck.ToTupleLanguage(SourceLanguage));
            newTranslatorTask.Wait();
            var newTranslator = newTranslatorTask.Result;

            foreach (var item in Enum.GetValues(typeof(Language)))
            {
                if ((Language)item != SourceLanguage)
                    if (MLSToCheck.ToString((Language)item) != newTranslator.First(x => x.Item1 == (Language)item).Item2)
                    {
                        IsCorrect = false;
                        break;
                    }
            }
            return IsCorrect;
        }
    }
}
