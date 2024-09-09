using HRIS.Application.Interfaces;
using HRIS.Domain.Common;
using HRIS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using System;

namespace HRIS.Infrastructure;
public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
{
    private IConfiguration _configuration;
    private readonly ICurrentUserService _currentUserService;
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, ICurrentUserService currentUserService)
            : base(options)
    {
        _configuration = configuration;
        _currentUserService = currentUserService;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken)
    {
        return await Database.BeginTransactionAsync(cancellationToken);
    }

    public void CommitTransaction()
    {
        Database.CommitTransaction();
    }

    public void RollBackTransaction()
    {
        Database.RollbackTransaction();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Provide a default connection string if not already configured
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("HRIS.Infrastructure"));
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId?.ToUpper() ?? "System";
                    entry.Entity.Created = new DateTime();
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId?.ToUpper() ?? "System";
                    entry.Entity.LastModified = new DateTime();
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.LastModifiedBy = _currentUserService.UserId?.ToUpper() ?? "System";
                    entry.Entity.LastModified = new DateTime();
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    // OnModelCreating
    // Seed method is calling here
    protected override async void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
