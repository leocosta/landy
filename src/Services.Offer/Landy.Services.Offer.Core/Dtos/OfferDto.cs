using System;
using System.Collections.Generic;

namespace Landy.Services.Offer.Core.Dtos
{
    public class OfferDto
    {
        public Guid Id { get; set; }
        public Guid HostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AddressDto Locale { get; set; }
        public MoneyDto Amount { get; set; }
        public int AvailableUnits { get; set; }
        public IList<ImageDto> Images { get; set; }
    }
}