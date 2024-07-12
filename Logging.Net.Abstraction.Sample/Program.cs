using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Logging.Net.Abstraction.Sample
{
    internal class Program
    {
        static void ConfigureService(ServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("logs/logcc-.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}][{SourceContext}] {Message:lj}{NewLine}{Exception}",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day).CreateLogger();

            services.AddLogging(builder => builder.AddConsole().AddDebug().AddSerilog(Log.Logger));

            services.AddSingleton<ConsoleHost>();
        }

        static void Main(string[] args)
        {
            ServiceCollection services = new();
            ConfigureService(services);

            ApplicationCore.Init(services.BuildServiceProvider());

            var host = ApplicationCore.Current.ServiceProvider.GetRequiredService<ConsoleHost>();
            host.Start();
        }
    }
}
