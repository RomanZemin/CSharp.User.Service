using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs.Posts
{
    public class CreatePostDTO
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
