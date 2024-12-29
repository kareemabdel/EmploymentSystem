using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using EmploymentSystem.Domain.Entities.Comman;

namespace EmploymentSystem.Domain.Entities
{
    public class UserRole:BaseEntity
    {
        public int RoleId { get; set; }
        public Guid UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
