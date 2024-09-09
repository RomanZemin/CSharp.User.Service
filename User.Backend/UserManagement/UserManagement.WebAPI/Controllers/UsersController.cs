using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserManagement.Application.Interfaces;

namespace UserManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize] 
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersExcept()
        {
            // Получаем UserId из токена
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdClaim, out Guid userId))
            {
                // Передаем userId в метод сервиса для исключения текущего пользователя
                var users = await _userService.GetAllUsersExceptAsync(userId);
                return Ok(users);
            }
            else
            {
                return Unauthorized("Invalid UserId");
            }
        }
    }
}
