using Microsoft.AspNetCore.Mvc;
using _28Jul2026.Models;
using _28Jul2026.Services;

namespace _28Jul2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        // GET: api/product/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound($"Product with Id {id} was not found.");

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            var created = _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/product/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            bool updated = _productService.Update(id, product);
            if (!updated)
                return NotFound($"Product with Id {id} was not found.");

            return Ok(product);
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _productService.Delete(id);
            if (!deleted)
                return NotFound($"Product with Id {id} was not found.");

            return Ok($"Product with Id {id} was deleted.");
        }
    }
}
