using MediatR;
using Landy.Services.Notification.Core.Dtos;

namespace Landy.Services.Notification.Core.Events
{
    public class EmailMessageCreatedEvent : INotification
    {
        public EmailMessageDto Message { get; set; }
    }
}
