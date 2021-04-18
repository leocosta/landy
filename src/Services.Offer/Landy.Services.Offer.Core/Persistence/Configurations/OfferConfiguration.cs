using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landy.Services.Offer.Core.Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Entities.Offer>
    {
        public void Configure(EntityTypeBuilder<Entities.Offer> builder)
        {
            builder.ToTable("Offers");

            builder.Property(x => x.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.HasMany(e => e.Images)
                .WithOne(e => e.Offer);

            builder.OwnsOne(e => e.Locale)
                .Property(e => e.Street)
                .HasColumnName("AddressStreet");

            builder.OwnsOne(e => e.Locale)
                .Property(e => e.City)
                .HasColumnName("AddressCity");

            builder.OwnsOne(e => e.Locale)
                .Property(e => e.State)
                .HasColumnName("AddressState");

            builder.OwnsOne(e => e.Locale)
                .Property(e => e.ZipCode)
                .HasColumnName("AddressZipCode");

            builder.OwnsOne(e => e.Amount)
                .Property(e => e.Value)
                .HasColumnName("Amount");

            builder.OwnsOne(e => e.Amount)
                .Property(e => e.Currency)
                .HasColumnName("Currency");
        }
    }
}
