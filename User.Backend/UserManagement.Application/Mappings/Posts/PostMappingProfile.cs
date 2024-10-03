using AutoMapper;

using UserManagement.Application.DTOs.Posts;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Mappings.Posts
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostDTO>();
        }
    }
}
