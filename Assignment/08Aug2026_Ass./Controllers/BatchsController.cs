using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _08Aug2026_Ass.Data;
using _08Aug2026_Ass.Models;

namespace _08Aug2026_Ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/batches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            var batches = await _context.Batches
                .Include(b => b.Students)
                .ToListAsync();
            return Ok(batches);
        }

        // GET: api/batches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var batch = await _context.Batches
                .Include(b => b.Students)
                .FirstOrDefaultAsync(b => b.BatchId == id);

            if (batch == null)
                return NotFound($"Batch with Id {id} not found.");

            return Ok(batch);
        }

        // POST: api/batches
        [HttpPost]
        public async Task<ActionResult<Batch>> CreateBatch([FromBody] Batch batch)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBatch), new { id = batch.BatchId }, batch);
        }

        // PUT: api/batches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatch(int id, [FromBody] Batch batch)
        {
            if (id != batch.BatchId)
                return BadRequest("Batch Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingBatch = await _context.Batches.FindAsync(id);
            if (existingBatch == null)
                return NotFound($"Batch with Id {id} not found.");

            existingBatch.BatchName = batch.BatchName;
            existingBatch.StartDate = batch.StartDate;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/batches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            var batch = await _context.Batches
                .Include(b => b.Students)
                .FirstOrDefaultAsync(b => b.BatchId == id);

            if (batch == null)
                return NotFound($"Batch with Id {id} not found.");

            if (batch.Students != null && batch.Students.Any())
                return BadRequest("Cannot delete batch that has students assigned to it.");

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}