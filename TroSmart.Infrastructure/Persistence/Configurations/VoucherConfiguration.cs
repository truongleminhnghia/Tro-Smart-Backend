using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("vouchers");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .HasColumnName("voucher_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.HasMany(v => v.VoucherUsers)
                .WithOne(s => s.Voucher)
                .HasForeignKey(s => s.VoucherId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(v => v.VoucherTransactions)
                .WithOne(s => s.Voucher)
                .HasForeignKey(s => s.VoucherId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}