using Microsoft.Extensions.Configuration;
using Serilog;

namespace AluraSearcherRPA.Infrastructure.Logger
{
    public class Log
    {
        private static readonly ILogger logger;

        static Log()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                logger = new LoggerConfiguration()
                              .ReadFrom.Configuration(configuration)
                              .CreateLogger();

                if (logger is null)
                    throw new ArgumentNullException(nameof(logger));
            }
            catch
            {
                logger = new LoggerConfiguration()
                            .WriteTo.File(path: "Logs/rpa-.log",
                                          restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug,
                                          rollingInterval: RollingInterval.Day)
                            .WriteTo.Console()
                            .CreateLogger();
            }
        }

        public static void Debug(string message, Exception? ex = null) => Serilog.Log.Debug(ex, message);
        public static void Info(string message) => Serilog.Log.Information(message);
        public static void Warn(string message, Exception? ex = null) => Serilog.Log.Warning(ex, message);
        public static void Error(string message, Exception? ex = null) => Serilog.Log.Error(ex, message);
    }
}
