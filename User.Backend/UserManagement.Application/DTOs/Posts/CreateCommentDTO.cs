namespace UserManagement.Application.DTOs.Posts
{
    public class CreateCommentDTO
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public Guid PostId { get; set; }
    }
}
