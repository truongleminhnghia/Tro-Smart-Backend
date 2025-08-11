using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {

        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("properties");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("property_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(p => p.AddressId)
                .HasColumnName("address_id")
                .IsRequired();
            builder.HasOne(p => p.Address)
                .WithMany(a => a.Properties)
                .HasForeignKey(p => p.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Images)
                .WithOne(i => i.Property)
                .HasForeignKey(i => i.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Listings)
                .WithOne(l => l.Property)
                .HasForeignKey(l => l.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Histories)
                .WithOne(h => h.Property)
                .HasForeignKey(h => h.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Property)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Bookings)
                .WithOne(b => b.Property)
                .HasForeignKey(b => b.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Attentions)
                .WithOne(a => a.Property)
                .HasForeignKey(a => a.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);
                
            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}