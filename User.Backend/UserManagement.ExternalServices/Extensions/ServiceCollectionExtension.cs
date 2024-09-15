using Microsoft.Extensions.DependencyInjection;
using UserManagement.ExternalServices.ExternalServices.RabbitMq;

namespace UserManagement.ExternalServices.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureExternalServices(this IServiceCollection services)
        {
            services.AddScoped<RabbitMqConsumerService>();
        }
    }
}
