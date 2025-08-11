
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class VoucherUserConfiguration : IEntityTypeConfiguration<VoucherUser>
    {
        public void Configure(EntityTypeBuilder<VoucherUser> builder)
        {
            builder.ToTable("voucher_users");
            builder.HasKey(vu => vu.Id);
            builder.Property(vu => vu.Id)
                .HasColumnName("voucher_user_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }
    }
}