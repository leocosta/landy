using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Landy.Domain.Repositories;
using Landy.Services.Identity.Core.Commands;
using Landy.Services.Identity.Core.Dtos;
using Landy.Services.Identity.Core.Entities;
using Landy.Services.Identity.Core.Persistence.Repositories;
using Landy.Services.Notification.Grpc;
using System;
using static Landy.Services.Notification.Grpc.Email;
using Landy.Services.Identity.Core.Commands.Validators;

namespace src.Services.Identity.Landy.Services.Identity.Core.Commands.Handlers
{
    public class UserCommandHandler :
        IRequestHandler<CreateUserCommand, CreateUserResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly Email.EmailClient emailClient;
        private readonly CreateUserCommandValidator commandValidator = new CreateUserCommandValidator();

        public UserCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper,
            EmailClient emailClient)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.emailClient = emailClient;
        }

        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            commandValidator.ValidateAndThrow(command);

            var user = mapper.Map<User>(command.User);

            await userRepository.AddOrUpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            var request = new CreateEmailMessageRequest
            {
                Message = new EmailMessage
                {
                    Subject = "Bem-vindo ao Landy!",
                    From = "contato@growiz.com.br",
                    Tos = user.Email,
                    Body = "Sua conta foi criada com sucesso."
                }
            };

            var response = await emailClient.CreateEmailMessageAsync(request);

            Console.WriteLine($"Message Id: { response.Message.Id }");

            var result = new CreateUserResult
            {
                User = mapper.Map<UserDto>(user)
            };

            return result;
        }
    }
}