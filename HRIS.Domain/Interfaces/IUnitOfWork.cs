using Microsoft.EntityFrameworkCore.Storage;

namespace HRIS.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
