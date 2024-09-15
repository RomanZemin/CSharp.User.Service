using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;

namespace UserManagement.ExternalServices.Extensions
{
    public static class RabbitMqConnectionExtensions
    {
        public static IServiceCollection AddRabbitMqConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnection>(sp =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = configuration["RabbitMq:HostName"],
                    UserName = configuration["RabbitMq:UserName"],
                    Password = configuration["RabbitMq:Password"],
                    VirtualHost = configuration["RabbitMq:VirtualHost"] // Если используете виртуальные хосты
                };

                return factory.CreateConnection();
            });

            return services;
        }
    }
}
