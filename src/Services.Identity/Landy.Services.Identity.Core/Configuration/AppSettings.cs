using Landy.Infrastructure.DistributedTracing;

namespace Landy.Services.Identity.Core.Configuration
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public ServiceOptions Services { get; set; }
        public DistributedTracingOptions DistributedTracing { get; set; }
    }

    public class ConnectionStrings
    {
        public string Identities { get; set; }
    }

    public class ServiceOptions
    {
        public ChannelServiceOptions Notification { get; set; }
    }

    public class ChannelServiceOptions
    {
        public string Grpc { get; set; }
    }
}