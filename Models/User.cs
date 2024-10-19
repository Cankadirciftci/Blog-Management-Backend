using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManagement.Models
{
   public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}


}