﻿namespace UserManagement.Application.DTOs.Posts
{
    public class CommentDTO
    {
        public Guid CommentId { get; set; }
        public string UserName { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
