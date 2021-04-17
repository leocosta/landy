using System;

namespace Landy.Domain.Entities
{
    public abstract class Entity<T> : IHasKey<T>, ITrackable
    {
        public T Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}