using System;

namespace Landy.Services.Booking.Core.Dtos
{
    public class BookDto
    {
        public Guid BookId { get; set; }
        public InkeeperDto Inkeeper { get; set; }
        public CustomerDto Customer { get; set; }
        public OfferDto Offer { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public byte Units { get; set; }
    }
}
