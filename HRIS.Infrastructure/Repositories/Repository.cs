using HRIS.Domain.Common;
using HRIS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Repositories
{
    public class Repository<T> where T : AuditableEntity
    {

        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public virtual async Task<List<T>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
