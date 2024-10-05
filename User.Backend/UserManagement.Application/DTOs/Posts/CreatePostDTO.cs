namespace UserManagement.Application.DTOs.Posts
{
    public class CreatePostDTO
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
