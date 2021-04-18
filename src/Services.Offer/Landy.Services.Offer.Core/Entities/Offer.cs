using System;
using System.Collections.Generic;
using Landy.Domain.Entities;
using Landy.Domain.ValueObjects;

namespace Landy.Services.Offer.Core.Entities
{
    public class Offer : AggregateRoot<Guid>
    {
        public Guid HostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Locale { get; set; }
        public Money Amount { get; set; }
        public int AvailableUnits { get; set; }
        public IReadOnlyCollection<Image> Images { get; set; }
    }
}