using System.Collections.Generic;
using System.Linq;
using BlogManagement.Data;
using BlogManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Comment>> GetComments()
        {
            var comments = _context.Comments.ToList();
            return Ok(comments);
        }

        [HttpGet("post/{postId}")]
        public ActionResult<List<Comment>> GetCommentsByPost(int postId)
        {
            var postComments = _context.Comments.Where(c => c.BlogPostId == postId).ToList();
            if (!postComments.Any())
            {
                return NotFound();
            }
            return Ok(postComments);
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public ActionResult<Comment> CreateComment([FromBody] Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateComment(int id, [FromBody] Comment updatedComment)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            comment.Content = updatedComment.Content;
            comment.Author = updatedComment.Author;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
