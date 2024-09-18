namespace UserManagement.Domain.Entities
{
    public class User_Chat
    {
        public Guid User_Chat_ID { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
