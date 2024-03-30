using Assignment03.Data;
using Assignment03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly Assignment03Context _context;

        public CommentsController(Assignment03Context context)
        {
            _context = context;
        }

        // GET: Comment/GetComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comments>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: Comment/GetComment/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Comments>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // POST: Comment/PostComment
        [HttpPost]
        public async Task<ActionResult<Comments>> PostComment(Comments comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
        }

        // PUT: Comment/Update/id
        [HttpPut]
        public async Task<IActionResult> Update(int id, [Bind("CommentId,Product,User,Rating,Image,Text")] Comments comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest("Comment ID in the URL does not match the Comment ID in the request body." + id + " " + comment.CommentId);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
            }
            return BadRequest(ModelState);
        }


        // DELETE: Comments/DeleteComment/id
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Comment deleted successfully.", CommentId = id });
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
