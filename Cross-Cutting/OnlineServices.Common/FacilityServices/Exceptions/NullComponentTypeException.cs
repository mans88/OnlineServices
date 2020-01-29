using OnlineServices.Common.Exceptions;
using System;

namespace OnlineServices.Common.FacilityServices.Exceptions
{
#if NETSTANDARD2_0
    [Serializable]
#endif
    public class NullComponentTypeException : LoggedException
    {
        private const string ExceptionMessage = "Not existing ComponentType.";
        public NullComponentTypeException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public NullComponentTypeException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public NullComponentTypeException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
