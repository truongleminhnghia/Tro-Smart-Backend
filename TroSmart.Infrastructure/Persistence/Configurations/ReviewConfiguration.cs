using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasColumnName("review_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(r => r.PropertyId)
                .HasColumnName("property_id")
                .IsRequired();
            builder.HasOne(r => r.Property)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(r => r.ReviewerId)
                .HasColumnName("reviewer_id")
                .IsRequired();
            builder.HasOne(r => r.Reviewer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}