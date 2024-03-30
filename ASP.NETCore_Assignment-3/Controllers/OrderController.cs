using Assignment03.Data;
using Assignment03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Assignment03Context _context;

        public OrderController(Assignment03Context context)
        {
            _context = context;
        }

        // GET: Order/GetOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Order.ToListAsync();
        }

        // GET: Order/GetOrder/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: Order/PostOrder
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // PUT: Order/Update/id
        [HttpPut]
        public async Task<IActionResult> Update(int id, [Bind("OrderId,RecordingOfSale")] Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Order ID in the URL does not match the Order ID in the request body." + id + " " + order.OrderId);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
            }
            return BadRequest(ModelState);
        }


        // DELETE: Orders/DeleteOrder/id
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Order deleted successfully.", OrderId = id });
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
