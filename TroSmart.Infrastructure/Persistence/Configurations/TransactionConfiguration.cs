using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("transaction_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(t => t.SubscriptionId)
                .HasColumnName("subscription_id")
                .IsRequired();
            builder.HasOne(t => t.Subscription)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.SubscriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.Payments)
                .WithOne(p => p.Transaction)
                .HasForeignKey(p => p.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.VoucherTransactions)
                .WithOne(vt => vt.Transaction)
                .HasForeignKey(vt => vt.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}