using MediatR;
using Landy.Services.Booking.Core.Configuration;
using Landy.Services.Booking.Core.Events;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BookingModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddBookingModuleCore(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddMessageBus(appSettings)
                .AddMediator();

            return services;
        }

         private static IServiceCollection AddMessageBus(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddMessageBusSender<BookCreatedEvent>(appSettings.MessageBroker);
            services.AddMessageBusReceiver<BookCreatedEvent>(appSettings.MessageBroker);

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
