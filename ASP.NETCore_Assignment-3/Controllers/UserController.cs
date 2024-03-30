using Assignment03.Data;
using Assignment03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Assignment03Context _context;

        public UserController(Assignment03Context context)
        {
            _context = context;
        }

        // GET: User/GetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        // GET: User/GetUser/id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: User/PostUser
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = User.UserId }, User);
        }

        // PUT: User/Update/id
        [HttpPut]
        public async Task<IActionResult> Update(int id, [Bind("UserId,Email,Password,UserName,PurchaseHistory,ShippingAddress")] User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("User ID in the URL does not match the User ID in the request body." + id + " " + user.UserId);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            }
            return BadRequest(ModelState);
        }


        // DELETE: Users/DeleteUser/id
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User deleted successfully.", UserId = id });
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }

    }
}
