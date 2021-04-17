using FluentValidation;
using MediatR;
using Landy.Services.Identity.Core.Dtos;

namespace Landy.Services.Identity.Core.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResult>
    {
        public UserDto User { get; set; }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(m => m.User).NotNull();
            RuleFor(m => m.User.Email).EmailAddress();
            RuleFor(m => m.User.Name).NotEmpty();
            RuleFor(m => m.User.Password)
                .MinimumLength(6)
                .MaximumLength(12);
        }
    }
}