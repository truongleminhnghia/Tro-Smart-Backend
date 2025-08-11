
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;
using TroSmart.Domain.Enums;

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

            builder.Property(a => a.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(a => a.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.Status)
                .HasColumnName("status")
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(AccountStatus.ACTIVE);

            builder.Property(a => a.RoleId)
                .HasColumnName("role_id")
                .IsRequired();

            builder.HasOne(a => a.Role)
                .WithMany()
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(a => a.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.HasOne(a => a.Customer)
                .WithOne(c => c.Account)
                .HasForeignKey<Customer>(c => c.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Employee)
                .WithOne(c => c.Account)
                .HasForeignKey<Employee>(c => c.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.ConversationMembers)
                .WithOne(cm => cm.Account)
                .HasForeignKey(cm => cm.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.ListingPost)
                .WithOne(l => l.PostBy)
                .HasForeignKey(l => l.PostById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Payments)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.PersonBookings)
                .WithOne(b => b.PersonBooking)
                .HasForeignKey(b => b.PersonBookingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.ScheduledBookings)
                .WithOne(b => b.PersonScheduled)
                .HasForeignKey(b => b.PersonScheduledId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.SenderMessages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(a => a.CreatedAt)
                .HasColumnName("created_at");
            builder.Property(a => a.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}