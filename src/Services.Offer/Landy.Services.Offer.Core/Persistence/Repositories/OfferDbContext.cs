using System;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Landy.Domain.Repositories;

namespace Landy.Services.Offer.Core.Persistence.Repositories
{

    public class OfferDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction dbContextTransaction;

        public OfferDbContext(DbContextOptions<OfferDbContext> options)
            : base(options)
        {
        }

        public IDisposable BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            dbContextTransaction = Database.BeginTransaction(isolationLevel);

            return dbContextTransaction;
        }

        public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return dbContextTransaction;
        }

        public void CommitTransaction()
        {
            dbContextTransaction.Commit();
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await dbContextTransaction.CommitAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}