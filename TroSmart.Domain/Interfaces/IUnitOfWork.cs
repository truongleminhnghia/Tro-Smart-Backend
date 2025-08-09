
namespace TroSmart.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IRoleRepository Roles { get; }
        IAddressRepository Address { get; }
        IAttentionRepository Attentions { get; }
        IBookingRepository Bookings { get; }
        IConversationRepository Conversations { get; }
        IConversationMemberRepository ConversationMembers { get; }
        ICustomerRepository Customers { get; }
        IEmployeeRepository Employees { get; }
        IHistoryRepository Histories { get; }
        IImageRepository Images { get; }
        IListingRepository Listings { get; }
        IMessageRepository Messages { get; }
        IPackageRepository Packages { get; }
        IPaymentRepository Payments { get; }
        IPropertyRepository Properties { get; }
        IReviewRepository Reviews { get; }
        ISubscriptionRepository Subscriptions { get; }
        ITransactionRepository Transactions { get; }
        IVoucherRepository Vouchers { get; }
        IVoucherTranscationRepository VoucherTranscations { get; }
        IVoucherUserRepository VoucherUsers { get; }

        Task<int> SaveChangesAsync();
        Task<int> SaveChangesWithTransactionAsync();
        int SaveChangesWithTransaction();
    }
}