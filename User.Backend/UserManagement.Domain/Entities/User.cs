namespace UserManagement.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PublicName { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public string ActivityType { get; set; }
    }
}
