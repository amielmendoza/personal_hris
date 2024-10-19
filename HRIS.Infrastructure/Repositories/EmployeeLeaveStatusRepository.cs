using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class EmployeeLeaveStatusRepository : Repository<EmployeeLeaveStatus>, IEmployeeLeaveStatusRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeLeaveStatusRepository> _logger;
        public EmployeeLeaveStatusRepository(ApplicationDbContext context, ILogger<EmployeeLeaveStatusRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<EmployeeLeaveStatus>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.EmployeeLeaveStatuses.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
