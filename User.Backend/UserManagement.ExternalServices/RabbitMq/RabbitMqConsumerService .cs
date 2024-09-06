using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;

namespace UserManagement.ExternalServices.RabbitMq
{
    public class RabbitMqConsumerService : IDisposable
    {
        private readonly IModel _channel;
        private readonly IUserService _userService;

        public RabbitMqConsumerService(IConnection connection, IUserService userService)
        {
            _channel = connection.CreateModel();
            _userService = userService;

            _channel.QueueDeclare(queue: "MyQueue",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                // Обработка сообщения
                await ProcessMessageAsync(message);
            };

            _channel.BasicConsume(queue: "MyQueue",
                                 autoAck: true,
                                 consumer: consumer);
        }

        private async Task ProcessMessageAsync(string message)
        {
            // Преобразуйте сообщение в объект и сохраните в базе данных
            var parts = message.Split(':');
            if (parts.Length == 2)
            {
                var userId = parts[0];
                var username = parts[1];

                var user = new User
                {
                    UserId = userId,
                    Username = username,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _userService.CreateUserAsync(user);
            }
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
