using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.ToTable("listings");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("listing_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.HasOne(l => l.Property)
                .WithMany(p => p.Listings)
                .HasForeignKey(l => l.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(l => l.PropertyId)
                .HasColumnName("property_id")
                .IsRequired();

            builder.HasOne(l => l.PostBy)
                .WithMany(a => a.ListingPost)
                .HasForeignKey(l => l.PostById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(l => l.PostById)
                .HasColumnName("post_by_id")
                .IsRequired();

            builder.HasMany(l => l.Subscriptions)
                .WithOne(s => s.Listing)
                .HasForeignKey(s => s.ListingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.ApprovedBy)
                .WithMany(a => a.ListingApprove)
                .HasForeignKey(l => l.ApprovedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(l => l.ApprovedById)
                .HasColumnName("approved_by_id")
                .IsRequired(false);

            builder.HasMany(l => l.Contacts)
                .WithOne(c => c.Listing)
                .HasForeignKey(c => c.ListingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(l => l.ContactId)
                .HasColumnName("contact_id")
                .IsRequired();

            builder.HasMany(l => l.Attentions)
                .WithOne(a => a.Listing)
                .HasForeignKey(a => a.ListingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(l => l.Histories)
                .WithOne(h => h.Listing)
                .HasForeignKey(h => h.ListingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(l => l.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(l => l.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}