using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Identity.BackgroundServices
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureIdentityServices(this IServiceCollection services)
        {
            services.AddHostedService<RabbitMqBackgroundService>();
        }
    }
}
