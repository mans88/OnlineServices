using OnlineServices.Common.Enumerations;
using OnlineServices.Common.Exceptions;

using System;
using System.Linq;

namespace OnlineServices.Common.TranslationServices.TransfertObjects
{
    public class MultiLanguageString
    {
        public MultiLanguageString(string English, string French, string Dutch)
        {
            this.English = English;
            this.French = French;
            this.Dutch = Dutch;
        }

        public MultiLanguageString(Tuple<Language, string>[] tuples)
        {
            if (tuples.Length != Enum.GetNames(typeof(Language)).Length)
                throw new LoggedException($"Incorrect number of languages in the MultiLanguageString(***Tuple<Language,string>[]***) call");

            this.English = tuples.FirstOrDefault(x => x.Item1 == Language.English).Item2;
            this.French = tuples.FirstOrDefault(x => x.Item1 == Language.French).Item2;
            this.Dutch = tuples.FirstOrDefault(x => x.Item1 == Language.Dutch).Item2;
        }

        public string English { get; set; }
        public string French { get; set; }
        public string Dutch { get; set; }

        public string ToString(Language Langue)
        {
            switch (Langue)
            {
                case Language.English:
                    return English;
                case Language.French:
                    return French;
                case Language.Dutch:
                    return Dutch;
                default:
                    throw new LanguageNotSupportedException($"{typeof(MultiLanguageString)}. Value={(int)Langue}");
            }
        }

        public Tuple<Language, string> ToTupleLanguage(Language Langue)
        {
            switch (Langue)
            {
                case Language.English:
                    return new Tuple<Language, string>(Langue, English);
                case Language.French:
                    return new Tuple<Language, string>(Langue, French);
                case Language.Dutch:
                    return new Tuple<Language, string>(Langue, Dutch);
                default:
                    throw new LanguageNotSupportedException($"{typeof(MultiLanguageString)}. Value={(int)Langue}");
            }
        }
    }
}