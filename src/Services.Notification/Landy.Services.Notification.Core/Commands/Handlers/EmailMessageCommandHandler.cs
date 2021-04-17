using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Landy.Domain.Infrastructure.MessageBrokers;
using Landy.Services.Notification.Core.Events;

namespace Landy.Services.Notification.Core.Commands.Handlers
{
    public class EmailMessageCommandHandler :
            IRequestHandler<CreateEmailMessageCommand, CreateEmailMessageResult>
    {
        private readonly IMessageSender<EmailMessageCreatedEvent> emailMessageCreatedEventSender;

        public EmailMessageCommandHandler(
            IMessageSender<EmailMessageCreatedEvent> emailMessageCreatedEventSender) =>
                this.emailMessageCreatedEventSender = emailMessageCreatedEventSender;

        public async Task<CreateEmailMessageResult> Handle(CreateEmailMessageCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{ request.GetType() } handled.");

            request.Message.Id = Guid.NewGuid();
            var emailMessageCreatedEvent = new EmailMessageCreatedEvent
            {
                Message = request.Message
            };

            await emailMessageCreatedEventSender.SendAsync(
                message: emailMessageCreatedEvent,
                cancellationToken: cancellationToken);

            var result = new CreateEmailMessageResult
            {
                Message = request.Message
            };

            return result;
        }
    }
}
