using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Interfaces;

namespace UserManagement.WebAPI.Controllers
{
    public class PostsController : ControllerBase
    {
        private readonly IUserService _userService;

        public PostsController(IUserService userService)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            // Получить все посты
            return Ok();
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            // Получить пост по его Id
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsPaginated()
        {
            // Получить пагинацию постов
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPost()
        {
            // Создать пост
            return Ok();
        }

        [HttpPatch("{postId}")]
        public async Task<IActionResult> UpdatePost(Guid postId)
        {
            // Обновляет существующий пост
            return Ok();
        }
        
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            // Удалить существующий пост
            return Ok();
        }

        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetCommentsForPost(Guid postId)
        {
            // Получить все комментарии к посту
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentToPost(Guid postId)
        {
            // добавить комментарий к посту
            return Ok();
        }

        [HttpPost("{postId}/like")]
        public async Task<IActionResult> LikePost(Guid postId)
        {
            // лайнкуть пост
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UnlikePost(Guid postId)
        {
            // убрать лайк с поста
            return Ok();
        }

    }
}