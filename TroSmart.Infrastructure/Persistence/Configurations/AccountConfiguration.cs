
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasColumnName("account_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(a => a.CreatedAt)
                .HasColumnName("created_at");
            builder.Property(a => a.UpdateddAt)
                .HasColumnName("updated_at");
        }
    }
}