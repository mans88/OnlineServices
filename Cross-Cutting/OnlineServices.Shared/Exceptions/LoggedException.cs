using OnlineServices.Common.Extensions;

using Serilog;

using System;
using System.Runtime.Serialization;

namespace OnlineServices.Common.Exceptions
{
    public class LoggedException : Exception
    {
        public static ILogger Logger { get; set; } = LoggerConfigurator();

        public LoggedException() : base()
        {
            Logger ??= LoggerConfigurator();
            Logger.Error(this, "Default Call to CTOR @ LoggedException()");
        }

        public LoggedException(string message) : base(message)
        {
            //message.IsNullOrWhiteSpace(true);

            Logger ??= LoggerConfigurator();
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

            Logger ??= LoggerConfigurator();
            Logger.Error(innerException, message);
        }

        public LoggedException(string message, Exception innerException) : base(message, innerException)
        {
            if (innerException is null)
                innerException = new ArgumentNullException($"{nameof(innerException)} is null @ LoggedException(string, ***Exception***)");

            if (message.IsNullOrWhiteSpace())
                message = $"{nameof(message)} is null @ LoggedException(***string***, Exception)";

            Logger ??= LoggerConfigurator();
            Logger.Error(innerException, message);
        }

        protected LoggedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Logger ??= LoggerConfigurator();

            if (info is null)
                Logger.Error($"{nameof(info)} is null @ LoggedException(***SerializationInfo***, StreamingContext)");
            else
                Logger.Error("LoggedException(***SerializationInfo***, StreamingContext)", info);

            Logger.Error("LoggedException(SerializationInfo, ***StreamingContext***)", context);
        }

        private static ILogger LoggerConfigurator()
            => new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.ColoredConsole()
                .CreateLogger();
    }
}
