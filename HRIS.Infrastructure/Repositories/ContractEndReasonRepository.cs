using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class ContractEndReasonRepository : Repository<ContractEndReason>, IContractEndReasonRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ContractEndReasonRepository> _logger;
        public ContractEndReasonRepository(ApplicationDbContext context, ILogger<ContractEndReasonRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<ContractEndReason>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.ContractEndReasons.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
