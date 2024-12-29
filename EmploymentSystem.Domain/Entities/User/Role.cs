using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EmploymentSystem.Domain.Entities.Comman;

namespace EmploymentSystem.Domain.Entities
{
    public class Role:BaseEntity
    {
        public Role()
        {
            RoleUsers = new List<UserRole>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int RoleId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string NameAr { get; set; }

        public virtual ICollection<UserRole> RoleUsers { get; set; }
    }
}
