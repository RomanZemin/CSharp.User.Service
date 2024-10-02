namespace UserManagement.Domain.Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навигационные свойства
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
