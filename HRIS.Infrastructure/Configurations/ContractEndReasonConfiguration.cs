using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRIS.Infrastructure.Configurations
{
    public class ContractEndReasonConfiguration : IEntityTypeConfiguration<ContractEndReason>
    {
        public void Configure(EntityTypeBuilder<ContractEndReason> builder)
        {
            // Table name
            builder.ToTable("ContractEndReasons");

            // Primary key
            builder.HasKey(es => es.Id);

            // Properties
            builder.Property(es => es.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(es => es.Description)
                .HasMaxLength(500);

            // Indexes
            builder.HasIndex(es => es.Name)
                .IsUnique();
        }
    }
}
