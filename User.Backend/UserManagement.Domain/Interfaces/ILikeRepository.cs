using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces
{
    public interface ILikeRepository
    {
        Task AddLikeAsync(Like like);
        Task RemoveLikeAsync(Guid postId, string UserName);
    }
}
