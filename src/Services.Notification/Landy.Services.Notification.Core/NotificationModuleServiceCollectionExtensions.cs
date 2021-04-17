using MediatR;
using System.Reflection;
using Landy.Services.Notification.Core.Configuration;
using Landy.Services.Notification.Core.Events;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NotificationModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationModuleCore(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddMessageBus(appSettings)
                .AddMediator();

            return services;
        }

        private static IServiceCollection AddMessageBus(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddMessageBusSender<EmailMessageCreatedEvent>(appSettings.MessageBroker);
            services.AddMessageBusReceiver<EmailMessageCreatedEvent>(appSettings.MessageBroker);

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
