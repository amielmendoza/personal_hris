using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class EmployeeStatusRepository : Repository<EmployeeStatus>, IEmployeeStatusRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeStatusRepository> _logger;
        public EmployeeStatusRepository(ApplicationDbContext context, ILogger<EmployeeStatusRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<EmployeeStatus>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.EmployeeStatuses.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
