using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("packages");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("package_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.HasMany(p => p.Subscriptions)
                .WithOne(s => s.Package)
                .HasForeignKey(s => s.PackageId)
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