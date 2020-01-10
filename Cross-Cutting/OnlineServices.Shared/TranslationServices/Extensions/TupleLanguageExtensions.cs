using OnlineServices.Common.Enumerations;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace OnlineServices.Common.TranslationServices.Extensions
{
    public static class TupleLanguageExtensions
    {
        /// <summary>
        /// The class validades that the fields has all the values as specifyed by the translation service.
        /// </summary>
        /// <returns>
        ///     void. This method throw a exception when LanguageTuple is not valid.
        /// </returns>
        public static void IsValidWithThrow(this Tuple<Language, string> LanguageTuple)//, ILogger iLogger)
        {
            //CHECKS
            if (LanguageTuple is null)
            {
                //iLogger.Error(nameof(Args));
                var msg = $"{nameof(LanguageTuple)} is null @ TupleLanguageExtensions.IsValidWithThrow(this ***Tuple<Language,string>***)";
                throw new LoggedException(msg, new ArgumentNullException(msg));
            }

            if (!LanguageTuple.Item1.IsDefined())
                throw new LanguageNotSupportedException($"{nameof(LanguageTuple.Item1)} not defined with value= {(int)LanguageTuple.Item1} @ TupleLanguageExtensions.IsValidWithThrow(this Tuple<***Language***,string>)");

            if (LanguageTuple.Item2.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"Nothing to translate. {nameof(LanguageTuple.Item2)} @ TupleLanguageExtensions.IsValidWithThrow(this Tuple<Language,***string***>);";
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }
        }
    }
}
