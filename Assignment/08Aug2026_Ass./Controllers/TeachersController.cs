using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _08Aug2026_Ass.Data;
using _08Aug2026_Ass.Models;

namespace _08Aug2026_Ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var teachers = await _context.Teachers
                .Include(t => t.Courses)
                .ToListAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.TeacherId == id);

            if (teacher == null)
                return NotFound($"Teacher with Id {id} not found.");

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> CreateTeacher([FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.TeacherId }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.TeacherId)
                return BadRequest("Teacher Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null)
                return NotFound($"Teacher with Id {id} not found.");

            existingTeacher.Name = teacher.Name;
            existingTeacher.Email = teacher.Email;
            existingTeacher.Experience = teacher.Experience;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.TeacherId == id);

            if (teacher == null)
                return NotFound($"Teacher with Id {id} not found.");

            if (teacher.Courses != null && teacher.Courses.Any())
                return BadRequest("Cannot delete teacher who has courses assigned.");

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
