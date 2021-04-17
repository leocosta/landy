using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Landy.Services.Offer.Core.Dtos;

namespace Landy.Services.Offer.Core.Events.Handlers
{
    public class OfferEventHandler : INotificationHandler<OfferCreatedEvent>
    {
        private readonly Nest.IElasticClient elasticClient;

        public OfferEventHandler(Nest.IElasticClient elasticClient) => this.elasticClient = elasticClient;

        public async Task Handle(OfferCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Indexando oferta... { notification.Offer.OfferId }");

            var response = await elasticClient.UpdateAsync<OfferDto>(notification.Offer.OfferId, u => u
                .DocAsUpsert()
                .Doc(notification.Offer));
        }
    }
}