using System;

namespace Landy.Services.Offer.Core.Persistence.Repositories
{
    public class OfferRepository : Repository<Entities.Offer, Guid>, IOfferRepository
    {
        public OfferRepository(OfferDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}