namespace UserManagement.Application.DTOs.Posts
{
    public class LikeDTO
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
