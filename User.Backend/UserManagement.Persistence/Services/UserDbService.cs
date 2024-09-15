using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Persistence.Data;

namespace UserManagement.Persistence.Services
{
    public class UserDbService : IUserDbService
    {
        private readonly UserDbContext _context;

        public UserDbService(UserDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            try
            {
                // Логика добавления пользователя в базу данных
                if (string.IsNullOrEmpty(user.UserName))
                {
                    // Логировать или обработать ошибку
                    throw new Exception("Username cannot be null or empty.");
                }
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                Console.WriteLine($"User successfully saved: {user.UserName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
            }
        }
    }
}
