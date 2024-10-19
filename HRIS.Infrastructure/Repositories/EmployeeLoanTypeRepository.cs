using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class EmployeeLoanTypeRepository : Repository<EmployeeLoanType>, IEmployeeLoanTypeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeLoanTypeRepository> _logger;
        public EmployeeLoanTypeRepository(ApplicationDbContext context, ILogger<EmployeeLoanTypeRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<EmployeeLoanType>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.EmployeeLoanTypes.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
