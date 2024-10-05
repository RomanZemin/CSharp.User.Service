using System.ComponentModel.DataAnnotations;

namespace UserManagement.Application.DTOs.Posts
{
    public class PostDTO
    {
        public Guid PostId { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
