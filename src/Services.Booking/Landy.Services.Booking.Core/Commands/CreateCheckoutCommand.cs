using MediatR;
using Landy.Services.Booking.Commands;

namespace Landy.Services.Booking.Core.Commands
{
    public class CreateCheckoutCommand : IRequest<CreateCheckoutResult> {}
}