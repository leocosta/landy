using System;
using MediatR;

namespace src.Services.Offer.Landy.Services.Offer.Core.Queries
{
    public class GetOfferQuery : IRequest<GetOfferResult>
    {
        public Guid OfferId { get; set; }
    }
}