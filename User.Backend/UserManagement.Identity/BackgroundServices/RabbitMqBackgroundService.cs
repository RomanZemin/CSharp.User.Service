using Microsoft.Extensions.Hosting;
using UserManagement.ExternalServices.Extensions.RabbitMq;

namespace UserManagement.Identity.BackgroundServices
{
    public class RabbitMqBackgroundService : BackgroundService
    {
        private readonly RabbitMqConsumerService _consumerService;

        public RabbitMqBackgroundService(RabbitMqConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask; // Можно оставить пустым, если `RabbitMqConsumerService` уже обрабатывает сообщения
        }
    }
}
