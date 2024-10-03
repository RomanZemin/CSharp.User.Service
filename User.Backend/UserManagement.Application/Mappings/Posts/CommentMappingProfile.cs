using AutoMapper;
using UserManagement.Application.DTOs.Posts;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Mappings.Posts
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentDTO>();
        }
    }
}
