using MediatR;
using Landy.Services.Booking.Core.Dtos;

namespace Landy.Services.Booking.Core.Events
{
    public class BookCreatedEvent : INotification
    {
        public BookDto Book { get; set; }
    }
}