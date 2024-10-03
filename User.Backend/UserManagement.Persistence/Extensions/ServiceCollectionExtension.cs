using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UserManagement.Domain.Interfaces;
using UserManagement.Persistence.Data;
using UserManagement.Persistence.Repositories;

namespace UserManagement.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName)));

            // Регистрация контекста для постов
            services.AddDbContext<PostDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(PostDbContext).Assembly.FullName)));

            // Регистрация контекста для комментариев
            services.AddDbContext<CommentDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CommentDbContext).Assembly.FullName)));

            // Регистрация контекста для лайков
            services.AddDbContext<LikeDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(LikeDbContext).Assembly.FullName)));
        }
        public static void AddInfrastructureRepositoriesServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
        }
    }
}
