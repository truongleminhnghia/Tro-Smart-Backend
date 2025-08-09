using Microsoft.EntityFrameworkCore;
using TroSmart.Domain.Entities;
using TroSmart.Infrastructure.Persistence.Configurations;

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

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Attention> Attentions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherTranscation> VoucherTranscations { get; set; }
        public DbSet<VoucherUser> VoucherUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}