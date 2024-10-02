using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Configurations;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Table name
        builder.ToTable("Employees");

        // Primary key
        builder.HasKey(e => e.Id);

        // Properties
        builder.Property(e => e.UserId)
            .IsRequired();

        builder.Property(e => e.EmployeeNo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.HireDate)
            .IsRequired();

        builder.Property(e => e.Position)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.DailyRate)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.MonthlyRate)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Allowance)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.SSS)
            .HasMaxLength(20);

        builder.Property(e => e.TIN)
            .HasMaxLength(20);

        builder.Property(e => e.PHIC)
            .HasMaxLength(20);

        builder.Property(e => e.HDMF)
            .HasMaxLength(20);

        builder.Property(e => e.BirthCertificate)
            .HasMaxLength(100);

        builder.Property(e => e.BankAccountNumber)
            .HasMaxLength(50);

        builder.Property(e => e.Insurance)
            .IsRequired();

        builder.Property(e => e.NBIClearanceExpiration);

        builder.Property(e => e.BrgyClearanceIssueDate);

        builder.Property(e => e.PoliceClearanceIssueDate);

        builder.Property(e => e.MedCertIssueDate);

        builder.Property(e => e.SwabTestResultDate);

        builder.Property(e => e.NoOfDependents)
            .IsRequired();

        builder.Property(e => e.ContractEndDate);

        builder.Property(e => e.ContractEndReasonId);

        builder.Property(e => e.Trainings)
            .HasMaxLength(500);

        builder.Property(e => e.Remarks)
            .HasMaxLength(500);

        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(50);

        // Relationships
        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(e => e.EmployeeNo)
            .IsUnique();
    }
}
