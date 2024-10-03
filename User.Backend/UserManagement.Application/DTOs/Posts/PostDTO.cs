namespace UserManagement.Application.DTOs.Posts
{
    public class PostDTO
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }  // Может понадобиться для отображения имени автора
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
