using System;

namespace HRIS.Domain.Common
{
    public record ReferenceEntity : AuditableEntity
    {
        public ReferenceEntity()
        {
            
        }
        public ReferenceEntity(Guid id, string name, string code, string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
