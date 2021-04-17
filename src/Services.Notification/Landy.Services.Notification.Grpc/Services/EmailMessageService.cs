using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Landy.Services.Notification.Core.Commands;
using Landy.Services.Notification.Core.Dtos;

namespace Landy.Services.Notification.Grpc
{
    public class EmailMessageService : Email.EmailBase
    {
        private readonly ILogger<EmailMessageService> logger;
        private readonly IMediator mediator;

        public EmailMessageService(ILogger<EmailMessageService> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        public override async Task<CreateEmailMessageResponse> CreateEmailMessage(
            CreateEmailMessageRequest request, ServerCallContext context)
        {
            var emailMessage = new EmailMessageDto()
            {
                From = request.Message.From,
                Tos = request.Message.Tos,
                CCs = request.Message.CCs,
                BCCs = request.Message.BCCs,
                Subject = request.Message.Subject,
                Body = request.Message.Body,
            };

            var result = await mediator.Send(new CreateEmailMessageCommand(emailMessage));

            var response = new CreateEmailMessageResponse
            {
                Message = new EmailMessage
                {
                    Id = result.Message.Id.ToString()
                }
            };

            return response;
        }
    }
}
