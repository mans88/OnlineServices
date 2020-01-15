using OnlineServices.Common.Exceptions;
using System;

namespace OnlineServices.Common.FacilityServices.Exceptions
{
    [Serializable]
    public class NullIssueException : LoggedException
    {
        private const string ExceptionMessage = "Not existing Issue.";
        public NullIssueException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public NullIssueException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public NullIssueException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
