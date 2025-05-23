using eStoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eStoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("category/{categoryId:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategoriesById(int categoryId)
        {
            Console.WriteLine($"Executing category search for ID: {categoryId}");
            var products = await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            if (!products.Any()) return NotFound($"No products found in category {categoryId}.");
            return Ok(products);
        }

        [HttpGet("search/{name}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetByName(string name)
        {
            var products = await _context.Products
                .Where(p => p.ProductName.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            if (!products.Any()) return NotFound($"No products found matching '{name}'.");
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound($"Product with ID {id} hong tim thay.");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product updatedProduct)
        {
            if (id != updatedProduct.ProductId)
                return BadRequest("ID Noo Match.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound($"Product with ID {id} hong tim thay.");

            product.ProductName = updatedProduct.ProductName;
            product.UnitPrice = updatedProduct.UnitPrice;
            product.UnitsInStock = updatedProduct.UnitsInStock;
            product.CategoryId = updatedProduct.CategoryId;

            await _context.SaveChangesAsync();
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound($"Product with ID {id} hong tim thay.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
