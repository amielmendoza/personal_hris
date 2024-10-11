using System;
using HRIS.Domain.Common;

namespace HRIS.Domain.Entities
{
    public record EmployeeLoanType : ReferenceEntity
    {
        // Additional properties specific to EmployeeStatus can be added here
        public EmployeeLoanType(Guid id, string name, string code, string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
        }
    }
}
