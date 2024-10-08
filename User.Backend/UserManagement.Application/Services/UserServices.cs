using AutoMapper;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersExceptAsync(Guid userId)
        {
            var users = await _userRepository.GetAllUsersAsync();
            // Фильтруем список, исключая пользователя с текущим UserId
            var filteredUsers = users.Where(u => u.UserId != userId);
            return _mapper.Map<IEnumerable<UserDto>>(filteredUsers);
        }
        public async Task<UserDto> GetCurrentUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserDto>(user);
        }
    }
}