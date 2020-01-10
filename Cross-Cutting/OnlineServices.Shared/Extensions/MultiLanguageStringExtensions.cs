using OnlineServices.Common.Enumerations;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.TranslationServices;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace OnlineServices.Common.Extensions
{
    public static class MultiLanguageStringExtensions
    {
        public static T FillFromMultiLanguageString<T>(this T ToFill, MultiLanguageString multiLanguageString)
            where T : IMultiLanguageNameFields
        {
            if (multiLanguageString is null)
                throw new ArgumentNullException(nameof(multiLanguageString));

            ToFill.NameEnglish = multiLanguageString.English;
            ToFill.NameFrench = multiLanguageString.French;
            ToFill.NameDutch = multiLanguageString.Dutch;

            return ToFill;
        }

        public static MultiLanguageString ExtractToMultiLanguageString(this IMultiLanguageNameFields MultilanguageString)
        {
            if (MultilanguageString is null)
                throw new ArgumentNullException(nameof(MultilanguageString));

            return new MultiLanguageString(MultilanguageString.NameEnglish, MultilanguageString.NameFrench, MultilanguageString.NameDutch);
        }

        public static MultiLanguageString ToMultiLanguageString(this Tuple<Language, string>[] tupleLanguages)
        {
            if (tupleLanguages is null)
                throw new LoggedException(new ArgumentNullException($"{nameof(tupleLanguages)} is null @ MultiLanguageStringExtensions.ToMultiLanguageString"));

            return new MultiLanguageString(tupleLanguages);
        }
        public static Tuple<Language, string>[] ToTupleLanguages(this MultiLanguageString multiLanguageString)
        {
            if (multiLanguageString is null)
                throw new LoggedException(new ArgumentNullException($"{nameof(multiLanguageString)} is null @ MultiLanguageStringExtensions.ToTupleLanguages"));

            var ReturnValues = new List<Tuple<Language, string>>
            {
                new Tuple<Language, string>(Language.English, multiLanguageString.ToString(Language.English)),
                new Tuple<Language, string>(Language.French, multiLanguageString.ToString(Language.French)),
                new Tuple<Language, string>(Language.Dutch, multiLanguageString.ToString(Language.Dutch))
            };

            return ReturnValues.ToArray();
        }

    }
}
