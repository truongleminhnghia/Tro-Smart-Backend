using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payments");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("payment_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(p => p.TransactionId)
                .HasColumnName("transaction_id")
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(p => p.Transaction)
                .WithMany(t => t.Payments)
                .HasForeignKey(p => p.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.AccountId)
                .HasColumnName("account_id")
                .IsRequired();
            builder.HasOne(p => p.Account)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.AccountId)
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