using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender? Sex { get; set; }
        public string City { get; set; }
        public string ActivityType { get; set; }
    }
}
