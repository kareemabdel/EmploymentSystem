using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using EmploymentSystem.Application.Interfaces;
using EmploymentSystem.Domain;
using EmploymentSystem.Infrastructure.ApplicationContext;
using EmploymentSystem.Infrastructure.EfRepositories;
using EmploymentSystem.Infrastructure.Services;
using Microsoft.Extensions.Options;

namespace EmploymentSystem.Infrastructure.IoC
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //     services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("MyConnection")));

        //    services.AddDbContext<ApplicationDbContext>(options =>
        //options.UseMySQL(configuration.GetConnectionString("MyConnection")));

            var mySqlConnectionStr = configuration.GetConnectionString("ApplicationDBConnection");
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(mySqlConnectionStr);
            });



            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<ICurrentUserService, CurrentUserService>();



            return services;
        }
    }
}
