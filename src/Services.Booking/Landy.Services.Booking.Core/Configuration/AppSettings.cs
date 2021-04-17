using Landy.Infrastructure.DistributedTracing;
using Landy.Infrastructure.MessageBrokers;

namespace Landy.Services.Booking.Core.Configuration
{
    public class AppSettings
    {
        public MessageBrokerOptions MessageBroker { get; set; }
        public DistributedTracingOptions DistributedTracing { get; set; }
    }
}