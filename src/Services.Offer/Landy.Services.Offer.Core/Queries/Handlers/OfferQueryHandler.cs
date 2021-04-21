using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Landy.Services.Offer.Core.Dtos;
using src.Services.Offer.Landy.Services.Offer.Core.Queries;

namespace Landy.Services.Offer.Core.Queries.Handlers
{
    public class OfferQueryHandler :
        IRequestHandler<GetOfferQuery, GetOfferResult>,
        IRequestHandler<GetOffersQuery, GetOffersResult>
    {
        private readonly Nest.IElasticClient elasticClient;

        public OfferQueryHandler(Nest.IElasticClient elasticClient) => this.elasticClient = elasticClient;

        public Task<GetOfferResult> Handle(GetOfferQuery request, CancellationToken cancellationToken)
        {
            var response = elasticClient.Get<OfferDto>(request.OfferId);

            var result = new GetOfferResult
            {
                Offer = response.Source
            };

            return Task.FromResult(result);
        }

        public Task<GetOffersResult> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var response = elasticClient.Search<OfferDto>(s => s
                .From(request.GetSkipOrDeafult())
                .Size(request.GetTakeOrDeafult())
                .Query(q => q
                    .Term(t => t.HostId, request.HostId) || q
                    .Match(mq => mq.Field(f => f.Title).Query(request.Title))
                )
            );

            var result = new GetOffersResult
            {
                Offers = response.Documents
            };

            return Task.FromResult(result);
        }
    }
}