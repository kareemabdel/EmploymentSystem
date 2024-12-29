//using CaseType = EmploymentSystem.Infrastructure.Entities.Application.Cases.CaseType;
using Microsoft.EntityFrameworkCore;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Enums;

namespace EmploymentSystem.Infrastructure.Seed
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {       
            //add  admin user,  password:123 
            modelBuilder.Entity<User>().HasData(
               new User { Id = Guid.Parse("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8"), Name = "Employer employer ", Email = "admin@company.com" ,Password= "iBbtmDi0qFeHHFgh+IXz5GklG0Jqy75i81vlpg136MY=", Phone= "11111111111",UserName= "emp1" }
           );
            modelBuilder.Entity<Role>().HasData(
              new Role { Id = (int)UserTypes.Employer, Name = UserTypes.Employer.ToString(), NameAr = "موظف" },
              new Role { Id = (int)UserTypes.Applicant, Name = UserTypes.Applicant.ToString(), NameAr = "مقدم الطلب" }
          );

            modelBuilder.Entity<UserRole>().HasData(
             new UserRole { UserId = Guid.Parse("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8"), RoleId = (int)UserTypes.Employer }
         );

        }
    }
}
