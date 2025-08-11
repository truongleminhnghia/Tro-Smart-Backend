using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("customer_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(c => c.FirstName)
                .HasColumnName("first_name")
                .IsRequired(false)
                .HasMaxLength(300);

            builder.Property(c => c.LastName)
                .HasColumnName("last_name")
                .IsRequired(false)
                .HasMaxLength(300);

            builder.Property(c => c.PhoneNumber)
                .HasColumnName("phone_number")
                .IsRequired(false)
                .HasMaxLength(15);

            builder.Property(c => c.Address)
                .HasColumnName("address")
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(c => c.DateOfBirth)
                .HasColumnName("date_of_birth")
                .IsRequired(false);

            builder.Property(c => c.Avatar)
                .HasColumnName("avatar")
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(c => c.Gender)
                .HasColumnName("gender")
                .HasConversion<string>()
                .IsRequired(false)
                .HasMaxLength(20);
            builder.Property(c => c.AccountId)
                .HasColumnName("account_id")
                .IsRequired();

            builder.HasOne(c => c.Account)
                .WithOne(a => a.Customer)
                .HasForeignKey<Customer>(c => c.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Attentions)
                .WithOne(a => a.CustomerAttention)
                .HasForeignKey(a => a.CustomerAttentionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Reviews)
                .WithOne(r => r.Reviewer)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(l => l.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(l => l.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}