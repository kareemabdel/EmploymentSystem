using Microsoft.EntityFrameworkCore;
using EmploymentSystem.Application.Interfaces;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Entities.Comman;
using EmploymentSystem.Infrastructure.Seed;
using EmploymentSystem.Domain.Entities.Vaccancy;

namespace EmploymentSystem.Infrastructure.ApplicationContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public virtual DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }  
        public DbSet<Vaccancy> Vaccancies { get; set; }  
        public DbSet<JobApplication> JobApplications { get; set; }  
        public DbSet<AuditTrial> AuditTrial { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken =new CancellationToken())
        { 
             var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserTrip>().HasOne(g => g.User).WithMany(p => p.UserTrips).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
            //     modelBuilder.Entity<City>().Property(p => p.CreationDate)
            //.HasDefaultValueSql("GETDATE()");
            modelBuilder.Seed();
            modelBuilder.Entity<UserRole>().HasKey(c => new { c.UserId, c.RoleId });
        }
    }
}
