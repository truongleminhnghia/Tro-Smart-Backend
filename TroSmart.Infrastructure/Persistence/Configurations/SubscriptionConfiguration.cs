using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("subscriptions");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasColumnName("subscription_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(s => s.PackageId)
                .HasColumnName("package_id")
                .IsRequired();
            builder.HasOne(s => s.Package)
                .WithMany(p => p.Subscriptions)
                .HasForeignKey(s => s.PackageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.ListingId)
                .HasColumnName("listing_id")
                .IsRequired();

            builder.HasOne(s => s.Listing)
                   .WithMany(l => l.Subscriptions)
                   .HasForeignKey(s => s.ListingId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_subscriptions_listings_listing_id");

            builder.HasMany(s => s.Transactions)
                .WithOne(p => p.Subscription)
                .HasForeignKey(p => p.SubscriptionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}