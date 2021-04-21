using MediatR;
using Landy.Services.Identity.Core.Dtos;

namespace Landy.Services.Identity.Core.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResult>
    {
        public UserDto User { get; set; }
    }
}