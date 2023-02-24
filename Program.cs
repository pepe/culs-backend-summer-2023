using Microsoft.AspNetCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace LogsApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders())
            .UseSerilog((hostingContext, loggerConfiguration) => 
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
    }
}
