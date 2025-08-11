using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("images");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("image_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(i => i.Url)
                .HasColumnName("url")
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(i => i.PropertyId)
                .HasColumnName("property_id")
                .IsRequired();

            builder.HasOne(i => i.Property)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}