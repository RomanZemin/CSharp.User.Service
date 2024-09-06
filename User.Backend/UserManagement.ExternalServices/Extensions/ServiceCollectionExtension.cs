using Microsoft.Extensions.DependencyInjection;
using UserManagement.ExternalServices.Extensions.RabbitMq;

namespace UserManagement.ExternalServices.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureExternalServices(this IServiceCollection services)
        {
            services.AddSingleton<RabbitMqConsumerService>();
        }
    }
}
