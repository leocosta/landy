using System;
using MediatR;

namespace src.Services.Offer.Landy.Services.Offer.Core.Queries
{
    public class GetOffersQuery : IRequest<GetOffersResult>
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public Guid HostId { get; set; }
        public string Title { get; set; }

        public int GetSkipOrDeafult() => Skip ?? 0;
        public int GetTakeOrDeafult() => Take ?? 50;
    }
}