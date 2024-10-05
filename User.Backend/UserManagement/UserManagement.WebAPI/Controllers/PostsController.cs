using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using UserManagement.Application.DTOs.Posts;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Exceptions;

namespace UserManagement.WebAPI.Controllers
{
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;

        public PostsController(
            IPostService postService,
            ICommentService commentService,
            ILikeService likeService)
        {
            _postService = postService;
            _commentService = commentService;
            _likeService = likeService;
        }

        #region PostAPI
        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            if (posts == null || !posts.Any()) throw new PostNotFoundException("Посты не найдены");
            return Ok(posts);
        }

        [HttpGet("posts/{postId}")]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);
            if (post == null) throw new PostNotFoundException("Пост не найден");
            return Ok(post);
        }

        [HttpGet("posts/paginated")]
        public async Task<IActionResult> GetAllPostsPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var posts = await _postService.GetAllPostsPaginatedAsync(pageNumber, pageSize);
            if (posts == null || !posts.Any()) return Empty;
            return Ok(posts);
        }

        [HttpPost("posts")]
        public async Task<IActionResult> CreateNewPost([FromBody] PostDTO post)
        {
            if (string.IsNullOrWhiteSpace(post.Content))
            {
                return BadRequest("Content cannot be empty.");
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                if (Guid.TryParse(userIdClaim, out Guid userId))
                {
                    post.PostId = Guid.NewGuid();
                    await _postService.CreateNewPostAsync(post, userId);
                    return CreatedAtAction(nameof(GetPostById), new { postId = post.PostId }, post);
                }
                else
                {
                    return Unauthorized("Invalid UserId");
                }

            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                throw new InvalidOperationException($"Ошибка при создании поста: {ex.Message} Внутренняя ошибка: {innerException}");
            }
        }

        [HttpPatch("posts/{postId}")]
        public async Task<IActionResult> ChangeContentPost(Guid postId, string content)
        {
            try
            {
                await _postService.ChangeContentPostAsync(postId, content);
                return NoContent();
            }
            catch (PostNotFoundException ex)
            {
                throw new PostNotFoundException($"Пост с ID {postId} не найден для редактирования. " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутрення ошибка сервера: {ex.Message}");
            }
        }
        
        [HttpDelete("posts/{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            try
            {
                await _postService.DeletePostAsync(postId);
                return NoContent();
            }
            catch (PostNotFoundException ex)
            {
                throw new PostNotFoundException($"Пост с ID {postId} не найден для удаления. " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Ошибка при удалении поста: {ex.Message}");
            }
        }
        #endregion

        #region CommentAPI
        [HttpGet("posts/{postId}/comments")]
        public async Task<IActionResult> GetCommentsForPost(Guid postId)
        {
            var comments = await _commentService.GetCommentsForPostAsync(postId);
            if (comments == null || !comments.Any()) throw new CommentNotFoundException("Комментарии не найдены");
            return Ok(comments);
        }


        [HttpGet("comments/{commentId}")]
        public async Task<IActionResult> GetCommentById(Guid commentId)
        {
            var comment = await _commentService.GetCommentByIdAsync(commentId);
            if (comment == null) throw new CommentNotFoundException("Комментарий не найден");
            return Ok(comment);
        }

        [HttpGet("comments/paginated")]
        public async Task<IActionResult> GetCommentsForPostPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var comments = await _commentService.GetCommentsForPostPaginatedAsync(pageNumber, pageSize);
            if (comments == null || !comments.Any()) throw new PostNotFoundException("Комментарии не найдены");
            return Ok(comments);
        }

        [HttpPost("comments")]
        public async Task<IActionResult> AddCommentToPost(CreateCommentDTO comment)
        {
            try
            {
                await _commentService.AddCommentToPostAsync(comment);
                return CreatedAtAction(nameof(GetPostById), new { id = comment.PostId }, comment);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка при создании поста" + ex.Message);
            }
        }

        [HttpDelete("comments/{commentId}")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            try
            {
                await _commentService.DeleteCommentAsync(commentId);
                return NoContent();
            }
            catch (PostNotFoundException ex)
            {
                throw new PostNotFoundException($"Комментарий с ID {commentId} не найден для удаления. " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Ошибка при удалении комментария: {ex.Message}");
            }
        }
        #endregion

        #region LikeAPI
        [HttpPost("posts/{postId}/like")]
        public async Task<IActionResult> LikePost(LikeDTO likecontent)
        {
            try
            {
                await _likeService.LikePostAsync(likecontent);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new LikeNotFoundException($"Ошибка при поставлении лайка. " + ex.Message);
            }
        }

        [HttpPost("posts/{postId}/unlike")]
        public async Task<IActionResult> UnlikePost(LikeDTO likecontent)
        {
            try
            {
                await _likeService.LikePostAsync(likecontent);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new LikeNotFoundException($"Ошибка при снятии лайка. " + ex.Message);
            }
        }
        #endregion
    }
}