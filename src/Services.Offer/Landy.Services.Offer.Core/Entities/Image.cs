using System;
using Landy.Domain.Entities;

namespace Landy.Services.Offer.Core.Entities
{
    public class Image : Entity<Guid>
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public Offer Offer { get; internal set; }
    }
}