using HRIS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HRIS.Infrastructure;
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    private IConfiguration _configuration;
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Provide a default connection string if not already configured
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("HRIS.Infrastructure"));
        }
    }

    // OnModelCreating
    // Seed method is calling here
    protected override async void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
