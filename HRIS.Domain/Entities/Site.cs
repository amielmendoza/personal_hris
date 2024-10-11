using System;
using HRIS.Domain.Common;

namespace HRIS.Domain.Entities
{
    public record Site : ReferenceEntity
    {
        public ICollection<Department> Departments { get; private set; } = new List<Department>();

        public Site(Guid id, string name, string code, string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
        }
    }
}
