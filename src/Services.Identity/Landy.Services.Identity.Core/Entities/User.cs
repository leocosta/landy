using System;
using Landy.Domain.Entities;

namespace Landy.Services.Identity.Core.Entities
{
    public class User : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public int AccessFailedCount { get; set; }
    }
}