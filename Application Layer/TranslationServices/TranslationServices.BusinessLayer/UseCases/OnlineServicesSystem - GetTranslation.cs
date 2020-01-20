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
        public MultiLanguageString GetTranslations(ServiceAuthorization APIKey, Tuple<Language, string> TupleToTranslate)
        {
            //CHECKS
            APIKey.IsWellFormed($"API Key is necessary for the translation service to work. {nameof(APIKey)} @ OnlineServicesSystem.IsCorrectTranslation");

            TupleToTranslate.IsValidWithThrow();

            var TranslationTask = Translator.TranslateAsync(TupleToTranslate);
            TranslationTask.Wait();
            var Translated = TranslationTask.Result.ToList();

            //Cleaning the re-traduction of the posted string to avoid loosing the original serquence.
            Translated = Translated.Where(x=>x.Item1 != TupleToTranslate.Item1).ToList();
            Translated.Add(TupleToTranslate);

            //LOGIC HERE
            return new MultiLanguageString(Translated.ToArray());
        }
    }
}
