using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class AttentionConfiguration : IEntityTypeConfiguration<Attention>
    {
        public void Configure(EntityTypeBuilder<Attention> builder)
        {
            builder.ToTable("attentions");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasColumnName("attention_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(a => a.ListingId)
                .HasColumnName("listing_id");

            builder.Property(a => a.PropertyId)
                .HasColumnName("property_id");

            builder.Property(a => a.CustomerAttentionId)
                .HasColumnName("customer_attention_id");

            builder.Property(a => a.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(a => a.UpdatedAt)
                .HasColumnName("updated_at");

            builder.HasOne(a => a.Listing)
               .WithMany(l => l.Attentions)
               .HasForeignKey(a => a.ListingId)
               .OnDelete(DeleteBehavior.NoAction) // tránh multiple cascade paths
               .HasConstraintName("FK_attentions_listings_listing_id");

            builder.HasOne(a => a.Property)
                   .WithMany(p => p.Attentions)
                   .HasForeignKey(a => a.PropertyId)
                   .OnDelete(DeleteBehavior.NoAction) // hoặc SetNull nếu FK nullable
                   .HasConstraintName("FK_attentions_properties_property_id");

            builder.HasOne(c => c.CustomerAttention)
                   .WithMany(u => u.Attentions)
                   .HasForeignKey(c => c.CustomerAttentionId)
                   .OnDelete(DeleteBehavior.NoAction) // đường thứ ba cũng tắt cascade
                   .HasConstraintName("FK_attentions_accounts_account_id");
        }
    }
}