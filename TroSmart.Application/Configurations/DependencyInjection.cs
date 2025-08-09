using Microsoft.Extensions.DependencyInjection;

namespace TroSmart.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMappingDI().AddUseCaseDI();
            return services;
        }
    }
}