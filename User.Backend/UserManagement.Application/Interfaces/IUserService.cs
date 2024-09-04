using UserManagement.Application.DTOs;

namespace UserManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
