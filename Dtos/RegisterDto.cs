using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Models;

namespace BlogManagement.Dtos
{
    public class RegisterDto
    {
        public string? Username { get; set; }
        public string ?PasswordHash { get; set; }
    }
}