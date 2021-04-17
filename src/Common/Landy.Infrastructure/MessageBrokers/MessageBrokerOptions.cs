using Landy.Infrastructure.MessageBrokers.Kafka;

namespace Landy.Infrastructure.MessageBrokers
{
    public class MessageBrokerOptions
    {
        public string Provider { get; set; }

        public KafkaOptions Kafka { get; set; }
    }
}