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
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
