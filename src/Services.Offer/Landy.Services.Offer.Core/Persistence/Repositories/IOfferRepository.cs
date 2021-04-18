using System;
using Landy.Domain.Repositories;

namespace Landy.Services.Offer.Core.Persistence.Repositories
{
    public interface IOfferRepository : IRepository<Entities.Offer, Guid>
    {
    }
}