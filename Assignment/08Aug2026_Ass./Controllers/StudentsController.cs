using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _08Aug2026_Ass.Data;
using _08Aug2026_Ass.Models;

namespace _08Aug2026_Ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.Students
                .Include(s => s.Batch)
                .Include(s => s.Courses)
                .ToListAsync();
            return Ok(students);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(s => s.Batch)
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return NotFound($"Student with Id {id} not found.");

            return Ok(student);
        }

    
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var batchExists = await _context.Batches.AnyAsync(b => b.BatchId == student.BatchId);
            if (!batchExists)
                return BadRequest($"Batch with Id {student.BatchId} does not exist.");

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.StudentId)
                return BadRequest("Student Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
                return NotFound($"Student with Id {id} not found.");

            var batchExists = await _context.Batches.AnyAsync(b => b.BatchId == student.BatchId);
            if (!batchExists)
                return BadRequest($"Batch with Id {student.BatchId} does not exist.");

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.BatchId = student.BatchId;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound($"Student with Id {id} not found.");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
