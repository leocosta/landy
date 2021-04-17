using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Landy.Domain.Infrastructure.MessageBrokers;
using Landy.Services.Booking.Core.Events;

namespace Landy.Services.Booking.Background
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IMediator mediator;
        private readonly IMessageReceiver<BookCreatedEvent> bookCreatedEventReceiver;
        private readonly ActivitySource activitySource = new ActivitySource(nameof(Worker));

        public Worker (ILogger<Worker> logger, IMediator mediator, IMessageReceiver<BookCreatedEvent> bookCreatedEventReceiver)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.bookCreatedEventReceiver = bookCreatedEventReceiver;
        }

        protected override Task ExecuteAsync (CancellationToken stoppingToken)
        {
            bookCreatedEventReceiver?.Receive ((data, metaData) =>
            {
                using (var activity = activitySource.StartActivity(nameof(IMessageReceiver<BookCreatedEvent>)))
                {
                    mediator.Publish(data);
                }
            });

            return Task.CompletedTask;
        }
    }
}