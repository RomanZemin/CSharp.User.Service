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

            CreateMap<PostDTO, Post>()
                .ForMember(dest => dest.PostId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore()) 
                .ForMember(dest => dest.LikesCount, opt => opt.Ignore())
                .ForMember(dest => dest.CommentsCount, opt => opt.Ignore());
        }
    }
}
