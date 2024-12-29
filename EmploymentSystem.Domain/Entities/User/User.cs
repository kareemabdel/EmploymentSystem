using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EmploymentSystem.Domain.Entities.Comman;

namespace EmploymentSystem.Domain.Entities
{

    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = new List<UserRole>(); 
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }   
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
