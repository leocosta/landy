using System;
using Landy.Services.Identity.Core.Entities;

namespace Landy.Services.Identity.Core.Persistence.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(IdentityDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}