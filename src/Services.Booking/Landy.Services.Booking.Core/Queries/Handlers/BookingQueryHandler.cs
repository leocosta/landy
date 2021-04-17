using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Landy.Services.Booking.Core.Dtos;

namespace Landy.Services.Booking.Core.Queries.Handlers
{
    public class BookingQueryHandler : IRequestHandler<GetBookQuery, GetBookResult>
    {
        public Task<GetBookResult> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var result = new GetBookResult
            {
                Book = new BookDto
                {
                    BookId = Guid.NewGuid()
                }
            };

            return Task.FromResult(result);
        }
    }
}