using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Data;
using BlogManagement.Models;
using Microsoft.AspNetCore.Mvc;
using BlogManagement.Helpers;

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

        [HttpGet]
        public IActionResult GetUser(){

            var user = _context.Users.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserId([FromRoute] int id){

            var user = _context.Users.Find(id);
            if(user == null){
                return NotFound();
            }

            return Ok(user);

        }
        

        [HttpDelete("{id}")]

        public IActionResult UserDelete([FromRoute] int id){

            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if(user == null){
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}