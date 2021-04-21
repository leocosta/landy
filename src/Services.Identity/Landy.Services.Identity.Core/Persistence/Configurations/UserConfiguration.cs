using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Landy.Services.Identity.Core.Entities;

namespace Landy.Services.Identity.Core.Persistence.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");

            // Seed
            builder.HasData(new List<User>
            {
                new User
                {
                    Id = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F660"),
                    Name = "Leonardo Costa",
                    Email = "leonardo@growiz.com.br",
                    PasswordHash = "AQAAAAEAACcQAAAAELBcKuXWkiRQEYAkD/qKs9neac5hxWs3bkegIHpGLtf+zFHuKnuI3lBqkWO9TMmFAQ=="
                }
            });
        }
    }
}
