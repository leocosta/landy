using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Landy.Domain.Entities;
using Landy.Domain.Repositories;

namespace Landy.Services.Offer.Core.Persistence.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : AggregateRoot<TKey>
    {
        private readonly OfferDbContext dbContext;

        protected DbSet<T> DbSet => dbContext.Set<T>();

        public IUnitOfWork UnitOfWork { get => dbContext; }

        public Repository(OfferDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddOrUpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity.Id.Equals(default(TKey)))
            {
                entity.CreatedAt = DateTimeOffset.UtcNow;
                await DbSet.AddAsync(entity, cancellationToken);
            }
            else
            {
                entity.UpdatedAt = DateTimeOffset.UtcNow;
            }
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public Task<T1> FirstOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.FirstOrDefaultAsync();
        }

        public Task<T1> SingleOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.SingleOrDefaultAsync();
        }

        public Task<List<T1>> ToListAsync<T1>(IQueryable<T1> query)
        {
            return query.ToListAsync();
        }
    }
}
