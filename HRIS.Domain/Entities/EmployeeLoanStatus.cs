using System;
using HRIS.Domain.Common;

namespace HRIS.Domain.Entities
{
    public record EmployeeLoanStatus : ReferenceEntity
    {
        // Additional properties specific to EmployeeStatus can be added here
        public EmployeeLoanStatus(Guid id, string name, string code, string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
        }
    }
}
