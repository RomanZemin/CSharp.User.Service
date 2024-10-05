using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Entities
{
    public class Post
    {
        public Guid PostId { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int LikesCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;

        // Навигационные свойства
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

        // Конструктор
        public Post()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
    }
}