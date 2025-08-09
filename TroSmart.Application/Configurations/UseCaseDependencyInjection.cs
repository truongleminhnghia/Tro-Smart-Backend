using Microsoft.Extensions.DependencyInjection;

namespace TroSmart.Application.Configurations
{
    public static class UseCaseDependencyInjection
    {
        public static IServiceCollection AddUseCaseDI(this IServiceCollection services)
        {
            return services;
        }
    }
}