namespace UserManagement.Domain.Entities
{
    public class Like
    {
        public Guid LikeId { get; set; } = Guid.NewGuid();
        public Guid PostId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навигационные свойства
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
