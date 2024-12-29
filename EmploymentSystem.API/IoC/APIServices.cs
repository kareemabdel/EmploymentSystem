using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using NLog;
using EmploymentSystem.API.Middleware.ResponseHandling;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.EmailServices;

namespace EmploymentSystem.API.IoC
{
    public static class APIServices
    {
        public static void AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
                {
                    options.Filters.Add<UnifyResponseFilter>();
                });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmploymentSystem API", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                };
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{{ securityScheme, Array.Empty<string>() }});
            });

            var hosts = configuration.GetSection("Cors:AllowedOrigins").Get<List<string>>();
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowedOrigins", p =>
                {
                    p.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(hosts.ToArray());
                });
            });

           


           services.AddAutoMapper(typeof(MappingProfile));
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            // return services;
        }
    }
}
