
namespace TroSmart.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesWithTransactionAsync();
        int SaveChangesWithTransaction();
    }
}