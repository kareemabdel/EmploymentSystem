using EmploymentSystem.Domain.Entities.Comman;
using EmploymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities.Vaccancy
{
    public class Vaccancy:BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxApplications { get; set; }
        public int CurrentApplications { get; set; }
        public DateTime ExpiredDate { get; set; }
        public VaccancyStatusEnum Status { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }

    }
}
