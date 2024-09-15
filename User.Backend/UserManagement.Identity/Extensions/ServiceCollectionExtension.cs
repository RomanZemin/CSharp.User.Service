using Microsoft.Extensions.DependencyInjection;
using UserManagement.Identity.BackgroundServices;

namespace UserManagement.Identity.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureIdentityServices(this IServiceCollection services)
        {
            services.AddHostedService<RabbitMqBackgroundService>();
        }
    }
}
