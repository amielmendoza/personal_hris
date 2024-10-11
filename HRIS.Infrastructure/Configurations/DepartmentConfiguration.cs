using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRIS.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table name
            builder.ToTable("Departments");

            // Primary key
            builder.HasKey(d => d.Id);

            // Properties
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Description)
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(d => d.Site)
                .WithMany(s => s.Departments)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.NoAction);

            // Indexes
            builder.HasIndex(d => d.Name)
                .IsUnique(false);
        }
    }
}