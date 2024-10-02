using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table name
        builder.ToTable("Users");

        // Primary key
        builder.HasKey(u => u.Id);

        // Properties
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.MiddleName)
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.MotherMaidenName)
            .HasMaxLength(100);

        builder.Property(u => u.Extension)
            .HasMaxLength(10);

        builder.Property(u => u.BirthDate)
            .IsRequired();

        builder.Property(u => u.BirthPlace)
            .HasMaxLength(200);

        builder.Property(u => u.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.ContactNo)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Gender)
            .IsRequired();

        builder.Property(u => u.MaritalStatus)
            .IsRequired();

        builder.Property(u => u.EmergencyContact)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.EmergencyContactNo)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(200);

        // Relationships
        builder.HasOne(u => u.Employee)
            .WithOne(e => e.User)
            .HasForeignKey<Employee>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}
