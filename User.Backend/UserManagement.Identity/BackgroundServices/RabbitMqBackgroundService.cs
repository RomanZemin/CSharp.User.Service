using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.ExternalServices.ExternalServices.RabbitMq;

namespace UserManagement.Identity.BackgroundServices
{
    public class RabbitMqBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public RabbitMqBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var consumerService = scope.ServiceProvider.GetRequiredService<RabbitMqConsumerService>();

                // Вызовите метод, который запускает обработку сообщений
                await consumerService.StartConsumingAsync(stoppingToken);
            }
        }
    }
}
