using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using System.Text.Json;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Enums;

namespace UserManagement.ExternalServices.ExternalServices.RabbitMq
{
    public class RabbitMqConsumerService : IDisposable
    {
        private readonly IModel _channel;
        private readonly IUserDbService _userDbService;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMqConsumerService(IConnection connection, IServiceProvider serviceProvider)
        {
            _channel = connection.CreateModel();
            _serviceProvider = serviceProvider;

            _channel.QueueDeclare(queue: "MyQueue",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public async Task StartConsumingAsync(CancellationToken cancellationToken)
        {
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

            await Task.Delay(Timeout.Infinite, cancellationToken); // Ожидание, пока не отменят
        }

        private async Task ProcessMessageAsync(string message)
        {
            Console.WriteLine($"Received message: {message}");

            using (var scope = _serviceProvider.CreateScope())
            {
                var userDbService = scope.ServiceProvider.GetRequiredService<IUserDbService>();

                try
                {
                    // Десериализация сообщения из JSON
                    var userDto = JsonSerializer.Deserialize<UserDto>(message);

                    if (userDto != null && Guid.TryParse(userDto.UserId, out Guid userId))
                    {
                        var user = new User
                        {
                            UserId = userId,
                            UserName = userDto.UserName,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };

                        await userDbService.CreateUserAsync(user);
                        Console.WriteLine($"User created: {user.UserName}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid UserId format or missing UserDto in message");
                    }
                }
                catch (JsonException jsonEx)
                {
                    Console.WriteLine($"Error deserializing message: {jsonEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");
                }
            }
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
