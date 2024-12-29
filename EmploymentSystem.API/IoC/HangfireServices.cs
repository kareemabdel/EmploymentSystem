using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using NLog;
using EmploymentSystem.API.Middleware.ResponseHandling;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.EmailServices;
using Hangfire;
using Hangfire.SqlServer;

namespace EmploymentSystem.API.IoC
{
    public static class HangfireServices
    {
        public static void AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config =>
            {
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                      .UseSimpleAssemblyNameTypeSerializer()
                      .UseDefaultTypeSerializer()
                      .UseSqlServerStorage(configuration.GetConnectionString("ApplicationDBConnection"), new SqlServerStorageOptions
                      {
                          CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                          SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                          QueuePollInterval = TimeSpan.Zero,
                          UseRecommendedIsolationLevel = true,
                          DisableGlobalLocks = true
                      });
            });

           services.AddHangfireServer();

            // return services;
        }
    }
}
