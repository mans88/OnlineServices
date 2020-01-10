using OnlineServices.Common.Enumerations;
using OnlineServices.Common.SecurityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;

namespace OnlineServices.Common.TranslationServices
{
    public interface ITRSServicesRole
    {
        //TODO Refactorer à Argument Pattern pour reduire redondance dans les checkes d'arguments.
        MultiLanguageString GetTranslations(ServiceAuthorization APIKey, Tuple<Language, string> TupleToTranslate);
        bool IsCorrectTranslation(ServiceAuthorization APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage);
    }
}