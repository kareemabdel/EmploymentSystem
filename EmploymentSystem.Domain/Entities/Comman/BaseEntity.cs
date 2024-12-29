using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Domain.Entities.Comman
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreationDate { get; set; } /*= DateTimeOffset.Now;*/
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletionDate { get; set; }

    }
}
