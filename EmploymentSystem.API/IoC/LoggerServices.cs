using Contracts;
using LoggerService;

namespace EmploymentSystem.API.IoC
{
    public static class LoggerServices
    {
        public static void ConfigureLoggerServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
