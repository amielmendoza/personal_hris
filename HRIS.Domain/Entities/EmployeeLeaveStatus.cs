using System;
using HRIS.Domain.Common;

namespace HRIS.Domain.Entities
{
    public record EmployeeLeaveStatus : ReferenceEntity
    {
        // Additional properties specific to EmployeeStatus can be added here
        public EmployeeLeaveStatus(Guid id, string name, string code, string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
        }
    }
}
