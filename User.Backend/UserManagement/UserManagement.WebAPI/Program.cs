using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Mappings;
using UserManagement.Application.Services;
using UserManagement.Domain.Interfaces;
using UserManagement.Persistence.Repositories;
using UserManagement.Persistence.Extensions;

namespace UserManagement.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAppDbContext(builder.Configuration);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAutoMapper(typeof(UserMappingProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "WebMonsters",
                    ValidAudience = "http://localhost:5250/api",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("881d43375578e3020726f4d36a5e779d40d3f972e1f3000090567237bca693bb61e4a339df26d38e98561ce5ed8b82f50d4e299a08ee07638c3a197c6c97f7dc"))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token invalid: " + context.Exception.Message);
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("Invalid token.");
                    }
                };
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins"); //Временное решение

            // Добавляем вызов UseAuthentication
            app.UseAuthentication();

            // Используем авторизацию
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
