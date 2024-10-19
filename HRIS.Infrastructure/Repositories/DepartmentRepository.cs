using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DepartmentRepository> _logger;
        public DepartmentRepository(ApplicationDbContext context, ILogger<DepartmentRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<Department>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.Departments.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
