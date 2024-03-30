using Assignment03.Data;
using Assignment03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace Assignment03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Assignment03Context _context;

        public ProductController(Assignment03Context context)
        {
            _context = context;
        }

        // GET: Product/GetProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: Product/GetProduct/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: Product/PostProduct
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // PUT: Product/Update/id
        [HttpPut]
        public async Task<IActionResult> Update(int id, [Bind("ProductId,Description,Image,Pricing,ShippingCost")] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Product ID in the URL does not match the Product ID in the request body." + id + " " + product.ProductId);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
            }
            return BadRequest(ModelState);
        }


        // DELETE: Products/DeleteProduct/id
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product deleted successfully.", ProductId = id });
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }


    }
}
