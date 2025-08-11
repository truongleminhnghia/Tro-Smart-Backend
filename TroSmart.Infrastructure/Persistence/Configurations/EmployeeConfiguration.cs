
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("employee_id")
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
                .WithOne(a => a.Employee)
                .HasForeignKey<Employee>(c => c.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.ListingApprove)
                .WithOne(l => l.ApprovedBy)
                .HasForeignKey(l => l.ApprovedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}