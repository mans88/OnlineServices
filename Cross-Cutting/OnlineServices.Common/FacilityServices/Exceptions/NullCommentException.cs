using OnlineServices.Common.Exceptions;
using System;

namespace OnlineServices.Common.FacilityServices.Exceptions
{
#if NETSTANDARD2_0
    [Serializable]
#endif
    public class NullCommentException : LoggedException
    {
        private const string ExceptionMessage = "Not existing Comment.";
        public NullCommentException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public NullCommentException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public NullCommentException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
