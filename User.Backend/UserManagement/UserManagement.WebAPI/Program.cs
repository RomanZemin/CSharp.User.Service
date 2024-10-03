using UserManagement.Application.Interfaces;
using UserManagement.Domain.Interfaces;
using UserManagement.Persistence.Repositories;
using UserManagement.Persistence.Extensions;
using UserManagement.ExternalServices.Extensions;
using UserManagement.Persistence.Services;
using UserManagement.Identity.Extensions;
using UserManagement.Application.Extensions;

namespace UserManagement.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAppDbContext(builder.Configuration);
            builder.Services.AddRabbitMqConnection(builder.Configuration);

            builder.Services.AddInfrastructureExternalServices();
            builder.Services.AddInfrastructureIdentityServices(builder.Configuration);

            builder.Services.AddScoped<IUserDbService, UserDbService>();
            
            builder.Services.AddCoreApplicationServices();
            builder.Services.AddInfrastructureRepositoriesServices();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                // Отключите временно Swagger и BrowserLink для тестирования
                app.UseSwagger();
                app.UseSwaggerUI();
                // app.UseBrowserLink();
            }

            
            app.UseCors("AllowAllOrigins"); //Временное решение

            // Добавляем вызов UseAuthentication
            app.UseAuthentication();
            app.UseHttpsRedirection();
            // Используем авторизацию
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
