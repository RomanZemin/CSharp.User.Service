using UserManagement.Application.DTOs;

namespace UserManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<UserDto>> GetAllUsersExceptAsync(Guid userId);
        Task<UserDto> GetCurrentUserAsync(Guid userId);
    }
}
