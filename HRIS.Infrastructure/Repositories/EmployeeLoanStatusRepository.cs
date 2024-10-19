using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class EmployeeLoanStatusRepository : Repository<EmployeeLoanStatus>, IEmployeeLoanStatusRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeLoanStatusRepository> _logger;
        public EmployeeLoanStatusRepository(ApplicationDbContext context, ILogger<EmployeeLoanStatusRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<EmployeeLoanStatus>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.EmployeeLoanStatuses.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
