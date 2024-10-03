namespace UserManagement.Application.DTOs.Posts
{
    public class CommentDTO
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
