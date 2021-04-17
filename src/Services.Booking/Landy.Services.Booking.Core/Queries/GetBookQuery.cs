using System;
using MediatR;

namespace Landy.Services.Booking.Core.Queries
{

    public class GetBookQuery : IRequest<GetBookResult>
    {
        public Guid BookId { get; set; }
    }
}
