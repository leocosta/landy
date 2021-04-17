using System;
using System.Threading;
using System.Threading.Tasks;
using Landy.Services.Booking.Core.Events;
using MediatR;
using Landy.Domain.Infrastructure.MessageBrokers;
using Landy.Services.Booking.Core.Commands;
using Landy.Services.Booking.Core.Dtos;

namespace Landy.Services.Booking.Commands.Handlers
{
    public class BookingCommandHandler :
        IRequestHandler<CreateBookCommand, CreateBookResult>,
        IRequestHandler<CreateCheckoutCommand, CreateCheckoutResult>
    {
        private readonly IMessageSender<BookCreatedEvent> bookCreatedEventSender;

        public BookingCommandHandler(IMessageSender<BookCreatedEvent> bookCreatedEventSender) => this.bookCreatedEventSender = bookCreatedEventSender;

        public async Task<CreateBookResult> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine($"{ request.GetType() } handled.");

            var persistedGuid = Guid.NewGuid();
            var bookCreatedEvent = new BookCreatedEvent
            {
                Book = new BookDto { BookId = persistedGuid }
            };

            await bookCreatedEventSender.SendAsync(bookCreatedEvent);

            var result = new CreateBookResult
            {
                BookId = persistedGuid
            };

            return result;
        }

        public Task<CreateCheckoutResult> Handle(CreateCheckoutCommand request, CancellationToken cancellationToken)
        {

            System.Console.WriteLine($"{ request.GetType() } handled.");

            return Task.FromResult(new CreateCheckoutResult(){ Text = "Its a checkout." });
        }
    }

}