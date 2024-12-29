using EmploymentSystem.Domain.Entities.Comman;
using EmploymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities.Vaccancy
{
    public class JobApplication:BaseEntity
    {
        public Guid Id { get; set; }
        public Guid VaccancyId { get; set; }
        public Guid UserId { get; set; }
        public JobApplicationStatus Status { get; set; } // viewd, rejected , accepted 
        public string CVBase64 { get; set; }
        public User User { get; set; }
        public Vaccancy Vaccancy { get; set; }
    }
}
