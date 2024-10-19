using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Models;

namespace BlogManagement.Dtos
{
    public class CreateCommentRequestDto
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int UserId { get; set; }
    }
}