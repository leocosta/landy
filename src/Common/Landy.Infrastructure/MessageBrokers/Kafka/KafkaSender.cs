using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using Landy.Domain.Infrastructure.MessageBrokers;

namespace Landy.Infrastructure.MessageBrokers.Kafka
{
    public class KafkaSender<T> : IMessageSender<T>, IDisposable
    {
        private readonly string topic;
        private readonly IProducer<Null, string> producer;

        public KafkaSender(string bootstrapServers, string topic)
        {
            this.topic = topic;

            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public void Dispose()
        {
            producer.Flush(TimeSpan.FromSeconds(10));
            producer.Dispose();
        }

        public async Task SendAsync(T message, MetaData metaData, CancellationToken cancellationToken = default)
        {
            _ = await producer.ProduceAsync(topic, new Message<Null, string>
            {
                Value = JsonConvert.SerializeObject(new Message<T>
                {
                    Data = message,
                    MetaData = metaData,
                }),
            }, cancellationToken);
        }
    }
}