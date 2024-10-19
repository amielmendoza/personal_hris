using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class SiteRepository : Repository<Site>, ISiteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SiteRepository> _logger;
        public SiteRepository(ApplicationDbContext context, ILogger<SiteRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<Site>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _context.Sites.ToListAsync().ConfigureAwait(true);

            return result.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
