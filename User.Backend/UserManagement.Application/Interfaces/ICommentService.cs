using UserManagement.Application.DTOs.Posts;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsForPostAsync(Guid postId);
        Task<IEnumerable<CommentDTO>> GetCommentsForPostPaginatedAsync(int pageNumber, int pageSize);
        Task<CommentDTO> GetCommentByIdAsync(Guid commentId);
        Task AddCommentToPostAsync(Comment comment);
        Task DeleteCommentAsync(Guid commentId);
    }
}
