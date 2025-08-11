using Microsoft.EntityFrameworkCore;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasColumnName("address_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(a => a.AddressDetails)
                .HasColumnName("address_details")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.Ward)
                .HasColumnName("ward")
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(a => a.Province)
                .HasColumnName("province")
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(a => a.Country)
                .HasColumnName("country")
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(a => a.LocationLatitude)
                .HasColumnName("location_latitude")
                .HasColumnType("float");

            builder.Property(a => a.LocationLongitude)
                .HasColumnName("location_longitude")
                .HasColumnType("float");

            builder.Property(a => a.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(a => a.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}