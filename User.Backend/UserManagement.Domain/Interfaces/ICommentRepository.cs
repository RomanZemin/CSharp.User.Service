using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsForPostAsync(Guid postId);
        Task<IEnumerable<Comment>> GetCommentsForPostPaginatedAsync(int pageNumber, int pageSize);
        Task<Comment> GetCommentByIdAsync(Guid commentId);
        Task AddCommentToPostAsync(Comment comment);
        Task DeleteCommentAsync(Guid commentId);
    }
}
