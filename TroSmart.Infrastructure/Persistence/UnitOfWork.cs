
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