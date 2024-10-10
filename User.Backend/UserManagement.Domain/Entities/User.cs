using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Description { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender? Sex { get; set; } = Gender.unspecified;
        public string? City { get; set; }
        public string? ActivityType { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

        public User()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
    }
}
