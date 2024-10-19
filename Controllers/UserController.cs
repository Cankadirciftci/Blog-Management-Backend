using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Data;
using BlogManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]

        public IActionResult AddUser([FromBody] User user)
        {
            if(user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash))
            {
                return BadRequest("Geçersiz kullanici bilgileri.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        
    }
}