using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Landy.Services.Offer.Core.Events;

namespace Landy.Services.Offer.Core.Commands.Handlers
{
    public class OfferCommandHandler :
            IRequestHandler<CreateOfferCommand, CreateOfferResult>
    {
        private readonly IMediator mediator;

        public OfferCommandHandler(IMediator mediator) => this.mediator = mediator;

        public async Task<CreateOfferResult> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine($"{ request.GetType() } handled.");

            var persistedGuid = Guid.NewGuid();
            var offerCreatedEvent = new OfferCreatedEvent
            {
                Offer = request.Offer
            };

            await mediator.Publish(offerCreatedEvent);

            var result = new CreateOfferResult
            {
                Offer = offerCreatedEvent.Offer
            };

            return result;
        }
    }
}