using System;
using Landy.Domain.Repositories;
using Landy.Services.Identity.Core.Entities;

namespace Landy.Services.Identity.Core.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}