using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(Guid postId);
        Task<IEnumerable<Post>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task CreateAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
    }
}
