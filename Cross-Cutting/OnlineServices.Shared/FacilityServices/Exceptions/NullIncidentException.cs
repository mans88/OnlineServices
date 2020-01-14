using OnlineServices.Common.Exceptions;
using System;

namespace OnlineServices.Common.FacilityServices.Exceptions
{
    [Serializable]
    public class NullIncidentException : LoggedException
    {
        private const string ExceptionMessage = "Not existing Issue.";
        public NullIncidentException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public NullIncidentException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public NullIncidentException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
