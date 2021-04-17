using MediatR;
using Landy.Services.Notification.Core.Dtos;

namespace Landy.Services.Notification.Core.Commands
{
    public class CreateEmailMessageCommand : IRequest<CreateEmailMessageResult>
    {
        public CreateEmailMessageCommand(EmailMessageDto messsage) => Message = messsage;

        public EmailMessageDto Message { get; set; }
    }
}