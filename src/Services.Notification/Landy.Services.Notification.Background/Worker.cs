using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Landy.Domain.Infrastructure.MessageBrokers;
using Landy.Services.Notification.Core.Events;

namespace Landy.Services.Notification.Background
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IMediator mediator;
        private readonly IMessageReceiver<EmailMessageCreatedEvent> emailMessageCreatedEventReceiver;

        public Worker(ILogger<Worker> logger,
            IMediator mediator,
            IMessageReceiver<EmailMessageCreatedEvent> emailMessageCreatedEventReceiver)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.emailMessageCreatedEventReceiver = emailMessageCreatedEventReceiver;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            emailMessageCreatedEventReceiver?.Receive((data, metaData) => mediator.Publish(data));

            return Task.CompletedTask;
        }
    }
}
