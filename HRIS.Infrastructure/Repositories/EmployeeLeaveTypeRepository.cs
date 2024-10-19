using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class EmployeeLeaveTypeRepository : Repository<EmployeeLeaveType>, IEmployeeLeaveTypeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeLeaveTypeRepository> _logger;
        public EmployeeLeaveTypeRepository(ApplicationDbContext context, ILogger<EmployeeLeaveTypeRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<EmployeeLeaveType>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.EmployeeLeaveTypes.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
