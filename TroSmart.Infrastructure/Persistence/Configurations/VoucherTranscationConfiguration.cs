
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class VoucherTranscationConfiguration : IEntityTypeConfiguration<VoucherTranscation>
    {
        public void Configure(EntityTypeBuilder<VoucherTranscation> builder)
        {
            builder.ToTable("voucher_transactions");
            builder.HasKey(vt => vt.Id);
            builder.Property(vt => vt.Id)
                .HasColumnName("voucher_transaction_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }
    }
}