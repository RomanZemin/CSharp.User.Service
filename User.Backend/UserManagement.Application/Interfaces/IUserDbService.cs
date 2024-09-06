using UserManagement.Domain.Entities;

namespace UserManagement.Application.Interfaces
{
    public interface IUserDbService
    {
        Task CreateUserAsync(User user);
    }
}
