﻿using System;

namespace HRIS.Domain.Common
{
    public abstract record AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
