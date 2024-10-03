using UserManagement.Application.DTOs.Posts;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByIdAsync(Guid postId);
        Task<IEnumerable<PostDTO>> GetAllPostsPaginatedAsync(int pageNumber, int pageSize);
        Task CreateNewPostAsync(PostDTO PostRequest);
        Task ChangeContentPostAsync(Guid postId, string content);
        Task DeletePostAsync(Guid psotId);
    }
}
