using Microsoft.EntityFrameworkCore;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Context
{
    public class TroSmartDbContext : DbContext
    {
        public TroSmartDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TroSmartDbContext()
        {
        }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new AccountConfiguration());
            // modelBuilder.ApplyConfiguration(new AddressConfiguration());
            // modelBuilder.ApplyConfiguration(new AttentionConfiguration());
            // modelBuilder.ApplyConfiguration(new BookingConfiguration());
            // modelBuilder.ApplyConfiguration(new ContactConfiguration());
            // modelBuilder.ApplyConfiguration(new ConversationConfiguration());
            // modelBuilder.ApplyConfiguration(new ConversationMemberConfiguration());
            // modelBuilder.ApplyConfiguration(new HistoryConfiguration());
            // modelBuilder.ApplyConfiguration(new ImageConfiguration());
            // modelBuilder.ApplyConfiguration(new ListingConfiguration());
            // modelBuilder.ApplyConfiguration(new MessageConfiguration());
            // modelBuilder.ApplyConfiguration(new PackageConfiguration());
            // modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            // modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            // modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            // modelBuilder.ApplyConfiguration(new RoleConfiguration());
            // modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            // modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            // modelBuilder.ApplyConfiguration(new VoucherConfiguration());
            // modelBuilder.ApplyConfiguration(new VoucherTranscationConfiguration());
            // modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            // modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

        private static readonly TimeZoneInfo _vnZone =
        TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        private DateTime GetCurrentVnTime()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _vnZone);
        }

        public override int SaveChanges()
        {
            ApplyTimestamps();
            return base.SaveChanges();
        }

        private void ApplyTimestamps()
        {
            DateTime now = GetCurrentVnTime();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(x => x.CreatedAt).IsModified = false;
                    entry.Entity.UpdatedAt = now;
                }
            }
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            ApplyTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}