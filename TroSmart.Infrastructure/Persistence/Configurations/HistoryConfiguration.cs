using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("histories");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("history_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(h => h.PropertyId)
                .HasColumnName("property_id")
                .IsRequired();

            builder.HasOne(h => h.Property)
                .WithMany()
                .HasForeignKey(h => h.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(h => h.ListingId)
                .HasColumnName("listing_id")
                .IsRequired();

            builder.HasOne(h => h.Listing)
                .WithMany()
                .HasForeignKey(h => h.ListingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(h => h.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(h => h.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

        }
    }
}