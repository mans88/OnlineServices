using System;

namespace OnlineServices.Common.Exceptions
{
#if NETSTANDARD2_0
    [Serializable]
#endif
    public class LanguageNotSupportedException : LoggedException
    {
        private const string ExceptionMessage = "Language Unknown or not properly configured";
        public LanguageNotSupportedException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public LanguageNotSupportedException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public LanguageNotSupportedException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
