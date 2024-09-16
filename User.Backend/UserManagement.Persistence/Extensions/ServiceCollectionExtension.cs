using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Persistence.Data;

namespace UserManagement.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        // Метод для добавления DbContext
        public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName)));
        }

        // Метод для добавления других инфраструктурных сервисов
        public static void AddInfrastructurePersistenceServices(this IServiceCollection services)
        {
            //// Интерсепторы для обработки действий перед сохранением в БД
            //services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            //// Регистрация репозиториев
            //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            //// Регистрация UnitOfWork
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
