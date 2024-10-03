using UserManagement.Application.DTOs.Posts;

namespace UserManagement.Application.Interfaces
{
    public interface ILikeService
    {
        Task LikePostAsync(LikeDTO likecontent);
        Task UnLikePostAsync(LikeDTO likecontent);
    }
}
