using MediatR;
using Landy.Services.Booking.Core.Dtos;

namespace Landy.Services.Booking.Core.Commands
{
    public class CreateBookCommand : IRequest<CreateBookResult>
    {
        public BookDto Book { get; set; }
    }
}