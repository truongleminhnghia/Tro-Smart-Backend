
using TroSmart.Application.Configurations;
using TroSmart.Infrastructure.Configurations;

namespace TroSmart.WebAPI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddInfrastructureDI().AddApplicationDI();
            return services;
        }
    }
}