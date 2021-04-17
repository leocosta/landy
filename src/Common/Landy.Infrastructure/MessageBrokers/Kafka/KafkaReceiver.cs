using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using Landy.Domain.Infrastructure.MessageBrokers;

namespace Landy.Infrastructure.MessageBrokers.Kafka
{
    public class KafkaReceiver<T> : IMessageReceiver<T>, IDisposable
    {
        private readonly IConsumer<Ignore, string> consumer;

        public KafkaReceiver(string bootstrapServers, string topic, string groupId)
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(topic);
        }

        public void Dispose()
        {
            consumer.Dispose();
        }

        public void Receive(Action<T, MetaData> action)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            Task.Factory.StartNew(() =>
            {
                try
                {
                    StartReceiving(action, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Closing consumer.");
                    consumer.Close();
                }
            });
        }

        private void StartReceiving(Action<T, MetaData> action, CancellationToken cancellationToken)
        {
            while (true)
            {
                try
                {
                    var consumeResult = consumer.Consume(cancellationToken);

                    if (consumeResult.IsPartitionEOF)
                    {
                        continue;
                    }

                    var message = JsonConvert.DeserializeObject<Message<T>>(consumeResult.Message.Value);
                    action(message.Data, message.MetaData);
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Consume error: {e.Error.Reason}");
                }
            }
        }
    }
}