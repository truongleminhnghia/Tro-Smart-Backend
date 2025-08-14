using Microsoft.Extensions.DependencyInjection;
using TroSmart.Domain.Interfaces;
using TroSmart.Domain.Interfaces.Base;
using TroSmart.Infrastructure.Persistence;
using TroSmart.Infrastructure.Persistence.Base;

namespace TroSmart.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            // base
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Repository
            
            return services;
        }
    }
}