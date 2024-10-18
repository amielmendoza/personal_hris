using System;

namespace HRIS.Domain.Common
{
    public record ReferenceEntity : AuditableEntity
    {
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
