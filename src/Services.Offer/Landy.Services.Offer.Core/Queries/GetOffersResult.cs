using System.Collections.Generic;
using Landy.Services.Offer.Core.Dtos;

namespace src.Services.Offer.Landy.Services.Offer.Core.Queries
{
    public class GetOffersResult
    {
        public IReadOnlyCollection<OfferDto> Offers { get; set; }
    }
}