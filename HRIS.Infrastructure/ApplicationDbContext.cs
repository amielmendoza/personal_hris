using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure;
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    // OnModelCreating
    // Seed method is calling here
    protected override async void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
