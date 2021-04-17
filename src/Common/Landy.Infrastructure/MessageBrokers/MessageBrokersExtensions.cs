using Landy.Domain.Infrastructure.MessageBrokers;
using Landy.Infrastructure.MessageBrokers;
using Landy.Infrastructure.MessageBrokers.Kafka;

namespace Microsoft.Extensions.DependencyInjection
{

    public static class MessageBrokersExtensions
    {
        public static IServiceCollection AddKafkaSender<T>(this IServiceCollection services, KafkaOptions options)
        {
            services.AddSingleton<IMessageSender<T>>(new KafkaSender<T>(options.BootstrapServers, options.Topics[typeof(T).Name]));

            return services;
        }

        public static IServiceCollection AddKafkaReceiver<T>(this IServiceCollection services, KafkaOptions options)
        {
            services.AddTransient<IMessageReceiver<T>>(i => new KafkaReceiver<T>(options.BootstrapServers,
                options.Topics[typeof(T).Name],
                options.GroupId));

            return services;
        }

        public static IServiceCollection AddMessageBusSender<T>(this IServiceCollection services, MessageBrokerOptions options)
        {
            services.AddKafkaSender<T>(options.Kafka);

            return services;
        }

        public static IServiceCollection AddMessageBusReceiver<T>(this IServiceCollection services, MessageBrokerOptions options)
        {
           services.AddKafkaReceiver<T>(options.Kafka);

            return services;
        }
    }
}