using MediatR;
using Landy.Services.Offer.Core.Dtos;

namespace Landy.Services.Offer.Core.Commands
{
    public class CreateOfferCommand : IRequest<CreateOfferResult>
    {
        public OfferDto Offer { get; set; }
    }
}