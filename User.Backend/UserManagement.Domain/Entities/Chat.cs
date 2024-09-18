namespace UserManagement.Domain.Entities
{
    public class Chat
    {
        public Guid ChatId { get; set; }
        public string? ChatName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
