using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManagement.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Author { get; set; }
    }
}