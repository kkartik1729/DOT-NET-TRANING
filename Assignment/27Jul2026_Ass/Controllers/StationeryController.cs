using Microsoft.AspNetCore.Mvc;
using StationeryApi.Models;

namespace StationeryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationeryController : ControllerBase
    {
        private static readonly List<StationeryItem> Items = new()
        {
            new StationeryItem { Id = 1, Name = "Notebook", Category = "Paper",   Price = 60,  Quantity = 100 },
            new StationeryItem { Id = 2, Name = "Ball Pen", Category = "Writing", Price = 10,  Quantity = 500 },
            new StationeryItem { Id = 3, Name = "Eraser",  Category = "Writing", Price = 5,   Quantity = 300 },
            new StationeryItem { Id = 4, Name = "GeometryBox", Category = "Tools",   Price = 120, Quantity = 50  },
            new StationeryItem { Id = 5, Name = "Stapler", Category = "Tools",   Price = 85,  Quantity = 40  }
        };

        private static int _nextId = 6;
        [HttpGet]
        public ActionResult<IEnumerable<StationeryItem>> GetAll()
        {
            return Ok(Items);
        }

        [HttpGet("{id:int}")]
        public ActionResult<StationeryItem> GetById(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound($"Stationery item with Id {id} was not found.");

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<StationeryItem> Create([FromBody] StationeryItem newItem)
        {
            newItem.Id = _nextId++;
            Items.Add(newItem);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] StationeryItem updatedItem)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound($"Stationery item with Id {id} was not found.");

            item.Name = updatedItem.Name;
            item.Category = updatedItem.Category;
            item.Price = updatedItem.Price;
            item.Quantity = updatedItem.Quantity;

            return Ok(item);
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartialUpdate(int id, [FromBody] StationeryItemPatchDto patch)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound($"Stationery item with Id {id} was not found.");

            if (patch.Name != null) item.Name = patch.Name;
            if (patch.Category != null) item.Category = patch.Category;
            if (patch.Price.HasValue) item.Price = patch.Price.Value;
            if (patch.Quantity.HasValue) item.Quantity = patch.Quantity.Value;

            return Ok(item);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound($"Stationery item with Id {id} was not found.");

            Items.Remove(item);
            return Ok($"Stationery item with Id {id} was deleted.");
        }
    }
}
