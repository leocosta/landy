using MediatR;
using Landy.Services.Offer.Core.Dtos;

namespace Landy.Services.Offer.Core.Events
{
    public class OfferCreatedEvent : INotification
    {
        public OfferDto Offer { get; set; }
    }
}