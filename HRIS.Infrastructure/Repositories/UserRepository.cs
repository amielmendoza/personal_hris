using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<List<User>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var Users = await _context.Users.ToListAsync().ConfigureAwait(true);

            return Users.ToPaginatedList(pageIndex, pageSize);
        }
    }
}
