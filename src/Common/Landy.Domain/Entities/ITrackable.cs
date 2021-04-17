using System;

namespace Landy.Domain.Entities
{
    public interface ITrackable
    {
        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset? UpdatedAt { get; set; }
    }
}