using System;

namespace OnlineServices.Common.Exceptions
{
#if NETSTANDARD2_0
    [Serializable]
#endif
    public class IsNullOrWhiteSpaceException : LoggedException
    {
        private const string ExceptionMessage = "String should not be Null, Empty or Whitespace";
        public IsNullOrWhiteSpaceException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public IsNullOrWhiteSpaceException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public IsNullOrWhiteSpaceException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
