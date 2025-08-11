using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("contacts");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("contact_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(c => c.ListingId)
                .HasColumnName("listing_id")
                .IsRequired();
            builder.HasOne(c => c.Listing)
                .WithMany(b => b.Contacts)
                .HasForeignKey(c => c.ListingId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(b => b.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(b => b.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}