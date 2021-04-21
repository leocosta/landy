using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Landy.Services.Booking.Core.Events.Handlers
{
    public class BookingEventHandler : INotificationHandler<BookCreatedEvent>
    {
        public Task Handle (BookCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Fazendo reserva... ");
            Thread.Sleep(5000);
            Console.WriteLine($"Reserva criada... { notification.Book.BookId  }");

            return Task.CompletedTask;
        }
    }
}