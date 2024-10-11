using System;
using System.ComponentModel.DataAnnotations.Schema;
using HRIS.Domain.Common;

namespace HRIS.Domain.Entities
{
    public record Department : ReferenceEntity
    {
        // Foreign key to Site
        public Guid SiteId { get; private set; }
        public Site Site { get; private set; }

        public Department(Guid id, string name, string code, string description, Guid siteId)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
            SiteId = siteId;
        }
    }
}