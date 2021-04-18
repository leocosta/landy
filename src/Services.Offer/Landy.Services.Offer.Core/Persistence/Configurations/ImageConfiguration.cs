using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landy.Services.Offer.Core.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Entities.Image>
    {
        public void Configure(EntityTypeBuilder<Entities.Image> builder)
        {
            builder.ToTable("Images");

            builder.Property(x => x.Id)
                .HasDefaultValueSql("newsequentialid()");
        }
    }
}
