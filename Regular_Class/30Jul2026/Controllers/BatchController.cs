using _30Jul2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace _30Jul2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBatches()
        {
            var batches = new List<Batch>
            {
                new Batch { Id = 1101, BatchName = "C#" },
                new Batch { Id = 1102, BatchName = "Asp.net" }
            };

            return Ok(batches);
        }
    }
}
