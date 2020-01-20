using OnlineServices.Common.Exceptions;
using System;

namespace OnlineServices.Common.FacilityServices.Exceptions
{
    [Serializable]
    public class NullFloorException : LoggedException
    {
        private const string ExceptionMessage = "Not existing Floor.";
        public NullFloorException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public NullFloorException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public NullFloorException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
