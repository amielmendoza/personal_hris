using HRIS.Domain.Common;

namespace HRIS.Domain.Interfaces
{
    public interface IRepository<T> where T : AuditableEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<List<T>> GetAllPaginatedAsync(int pageIndex, int pageSize);
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
