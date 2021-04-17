using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Landy.Infrastructure.DistributedTracing;
using Landy.Services.Booking.Core.Configuration;

namespace Landy.Services.Booking.Background
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;

                    var appSettings = new AppSettings();
                    configuration.Bind(appSettings);
                    services.AddSingleton(appSettings);

                    services.AddDistributedTracing(appSettings.DistributedTracing);

                    services.AddBookingModuleCore(appSettings);

                    services.AddHostedService<Worker>();
                });
    }
}
