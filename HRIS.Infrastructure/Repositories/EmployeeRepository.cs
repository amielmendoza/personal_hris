using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;
        public EmployeeRepository(ApplicationDbContext context, ILogger<EmployeeRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public Task AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var employees = await _context.Employees
                .Include(x => x.User)
                .Include(x => x.ContractEndReason)
                .Include(x => x.Site)
                .Include(x => x.Department)
                .Include(x => x.EmployeeStatus).ToListAsync().ConfigureAwait(true);

            return employees.ToPaginatedList(pageIndex, pageSize);
        }

        public Task<Employee> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
