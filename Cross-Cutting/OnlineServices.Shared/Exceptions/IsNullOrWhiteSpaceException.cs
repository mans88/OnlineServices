using System;

namespace OnlineServices.Common.Exceptions
{
    [Serializable]
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
