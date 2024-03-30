using Assignment03.Data;
using Assignment03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly Assignment03Context _context;

        public CartController(Assignment03Context context)
        {
            _context = context;
        }

        // GET: Cart/GetCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Cart.ToListAsync();
        }

        // GET: Cart/GetCart/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // POST: Cart/PostCart
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        }

        // PUT: Cart/Update/id
        [HttpPut]
        public async Task<IActionResult> Update(int id, [Bind("CartId,Products,Quantities,User")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest("Cart ID in the URL does not match the Cart ID in the request body." + id + " " + cart.CartId);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
            }
            return BadRequest(ModelState);
        }


        // DELETE: Carts/DeleteCart/id
        [HttpDelete]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Cart deleted successfully.", CartId = id });
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
}
