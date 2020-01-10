using System;

namespace OnlineServices.Common.Exceptions
{
    [Serializable]
    public class NecessaryDataException : LoggedException
    {
        private const string ExceptionMessage = "Necessary fields not properly configured";
        public NecessaryDataException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public NecessaryDataException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public NecessaryDataException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
