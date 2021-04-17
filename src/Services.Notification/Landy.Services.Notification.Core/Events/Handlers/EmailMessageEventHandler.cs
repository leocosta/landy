using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Landy.Services.Notification.Core.Events.Handlers
{
    public class EmailMessageEventHandler : INotificationHandler<EmailMessageCreatedEvent>
    {
        private readonly ILogger<EmailMessageCreatedEvent> logger;

        public EmailMessageEventHandler(ILogger<EmailMessageCreatedEvent> logger) => this.logger = logger;

        public Task Handle(EmailMessageCreatedEvent notification, CancellationToken cancellationToken)
        {
            //TODO: Send email with SendGrid

            logger.LogInformation(@$"Email was sent successfully to { notification.Message.Tos }");

            return Task.CompletedTask;
        }
    }
}
