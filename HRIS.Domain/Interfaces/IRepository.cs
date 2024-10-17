using HRIS.Domain.Common;

namespace HRIS.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<List<T>> GetAllPaginatedAsync(int pageIndex, int pageSize);
        Task AddAsync(T employee);
        Task UpdateAsync(T employee);
        Task DeleteAsync(Guid id);
    }
}
