using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Data;
using BlogManagement.Dtos;
using BlogManagement.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]   
    public class BlogPostContoller : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public BlogPostContoller(AppDbContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){

             var post = _context.BlogPosts.ToList();
            var blogPostDto = post.Select(s => s.ToBlogPostDto());
            return Ok(blogPostDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var post = _context.BlogPosts.Find(id);
            if(post == null){
                return NotFound();
            }
            return Ok(post.ToBlogPostDto());
        }

      [HttpPost]
public IActionResult Create([FromBody] CreateBlogPostRequestDto blogpostDto)
{
    var blogPostModel = blogpostDto.ToBlogPostFromCreateDto(); // Use renamed method here
    _context.BlogPosts.Add(blogPostModel);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetById), new { id = blogPostModel.Id }, blogPostModel.ToBlogPostDto());
}


        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]

        public IActionResult Delete([FromRoute] int id){
            var blogPostModel = _context.BlogPosts.FirstOrDefault(x => x.Id == id);

            if(blogPostModel == null){
               return NotFound();
            }
            _context.BlogPosts.Remove(blogPostModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}