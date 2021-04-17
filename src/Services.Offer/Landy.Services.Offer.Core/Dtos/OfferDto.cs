using System;
using System.Collections.Generic;

namespace Landy.Services.Offer.Core.Dtos
{
    public class OfferDto
    {
        public Guid OfferId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDto Innkeeper { get; set; }
        public double Price { get; set; }
        public int AvaiabilityUnits { get; set; }
        public AddressDto Address { get; set; }
        public IList<ImageDto> Images { get; set; }
    }
}