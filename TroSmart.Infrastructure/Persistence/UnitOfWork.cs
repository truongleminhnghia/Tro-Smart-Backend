
using Microsoft.EntityFrameworkCore;
using TroSmart.Domain.Interfaces;
using TroSmart.Infrastructure.Persistence.Context;

namespace TroSmart.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TroSmartDbContext _context;

        public UnitOfWork(TroSmartDbContext context)
        {
            _context = context;
        }
        public IAccountRepository Accounts => throw new NotImplementedException();

        public IRoleRepository Roles => throw new NotImplementedException();

        public IAddressRepository Address => throw new NotImplementedException();

        public IAttentionRepository Attentions => throw new NotImplementedException();

        public IBookingRepository Bookings => throw new NotImplementedException();

        public IConversationRepository Conversations => throw new NotImplementedException();

        public IConversationMemberRepository ConversationMembers => throw new NotImplementedException();

        public ICustomerRepository Customers => throw new NotImplementedException();

        public IEmployeeRepository Employees => throw new NotImplementedException();

        public IHistoryRepository Histories => throw new NotImplementedException();

        public IImageRepository Images => throw new NotImplementedException();

        public IListingRepository Listings => throw new NotImplementedException();

        public IMessageRepository Messages => throw new NotImplementedException();

        public IPackageRepository Packages => throw new NotImplementedException();

        public IPaymentRepository Payments => throw new NotImplementedException();

        public IPropertyRepository Properties => throw new NotImplementedException();

        public IReviewRepository Reviews => throw new NotImplementedException();

        public ISubscriptionRepository Subscriptions => throw new NotImplementedException();

        public ITransactionRepository Transactions => throw new NotImplementedException();

        public IVoucherRepository Vouchers => throw new NotImplementedException();

        public IVoucherTranscationRepository VoucherTranscations => throw new NotImplementedException();

        public IVoucherUserRepository VoucherUsers => throw new NotImplementedException();

        // SaveChangesWithTransaction đồng bộ
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"SaveChanges failed: {ex.Message}", ex);
            }
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                // Tạo một transaction scope
                await using var transaction =
                    await _context.Database.BeginTransactionAsync();
                try
                {
                    // Thực hiện lưu thay đổi
                    var result = await _context.SaveChangesAsync();

                    // Commit transaction
                    await transaction.CommitAsync();

                    return result;
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException($"Transaction failed: {ex.Message}", ex);
                }
            });
        }

        public int SaveChangesWithTransaction()
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return strategy.Execute(() =>
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    var result = _context.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException($"Transaction failed: {ex.Message}", ex);
                }
            });
        }
    }
}