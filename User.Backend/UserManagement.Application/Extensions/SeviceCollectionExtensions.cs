using Microsoft.Extensions.DependencyInjection;

using UserManagement.Application.Interfaces;
using UserManagement.Application.Mappings;
using UserManagement.Application.Services;

namespace UserManagement.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCoreApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILikeService, LikeService>();

            services.AddAutoMapper(typeof(UserMappingProfile));
        }
    }
}
