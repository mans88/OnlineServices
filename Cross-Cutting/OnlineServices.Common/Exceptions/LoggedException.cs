using OnlineServices.Common.Extensions;
using OnlineServices.Common.Logging;
using Serilog;
using System;
#if NETSTANDARD2_0
using System.Runtime.Serialization;
#endif

namespace OnlineServices.Common.Exceptions
{
#if NETSTANDARD2_0
    [Serializable]
#endif
    public class LoggedException : Exception
    {
        public static ILogger Logger { get; set; } = OnlineServicesLogger.LoggerConfigurator();

        public LoggedException() : base()
        {
            if (Logger == null)
                Logger = OnlineServicesLogger.LoggerConfigurator();
            Logger.Error(this, "Default Call to CTOR @ LoggedException()");
        }

        public LoggedException(string message) : base(message)
        {
            //message.IsNullOrWhiteSpace(true);

            if (Logger == null)
                Logger = OnlineServicesLogger.LoggerConfigurator();
            Logger.Error(message);
        }

        public LoggedException(Exception innerException) : base(innerException.Message, innerException)
        {
            string message;
            if (innerException is null)
                innerException = new ArgumentNullException($"{nameof(innerException)} is null @ LoggedException(***Exception***)");

            if (innerException.Message.IsNullOrWhiteSpace())
                message = $"{nameof(innerException.Message)} is null @ LoggedException(***string***, Exception)";
            else
                message = innerException.Message;

            if (Logger == null)
                Logger = OnlineServicesLogger.LoggerConfigurator();

            Logger.Error(innerException, message);
        }

        public LoggedException(string message, Exception innerException) : base(message, innerException)
        {
            if (innerException is null)
                innerException = new ArgumentNullException($"{nameof(innerException)} is null @ LoggedException(string, ***Exception***)");

            if (message.IsNullOrWhiteSpace())
                message = $"{nameof(message)} is null @ LoggedException(***string***, Exception)";

            if (Logger == null)
                Logger = OnlineServicesLogger.LoggerConfigurator();
            Logger.Error(innerException, message);
        }

#if NETSTANDARD2_0
        protected LoggedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (Logger == null)
                Logger = OnlineServicesLogger.LoggerConfigurator();

            if (info is null)
                Logger.Error($"{nameof(info)} is null @ LoggedException(***SerializationInfo***, StreamingContext)");
            else
                Logger.Error("LoggedException(***SerializationInfo***, StreamingContext)", info);

            Logger.Error("LoggedException(SerializationInfo, ***StreamingContext***)", context);
        }
#endif

    }
}
