using Microsoft.EntityFrameworkCore;
using EmploymentSystem.Domain.Entities.Comman;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Entities.Vaccancy;

namespace EmploymentSystem.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<City> Cities { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Role> Roles { get; set; }
         DbSet<Vaccancy> Vaccancies { get; set; }
         DbSet<JobApplication> JobApplications { get; set; }
        DbSet<AuditTrial> AuditTrial { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
