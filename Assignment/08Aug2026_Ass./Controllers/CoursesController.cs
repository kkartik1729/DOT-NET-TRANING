using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _08Aug2026_Ass.Data;
using _08Aug2026_Ass.Models;

namespace _08Aug2026_Ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _context.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Students)
                .ToListAsync();
            return Ok(courses);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
                return NotFound($"Course with Id {id} not found.");

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teacherExists = await _context.Teachers.AnyAsync(t => t.TeacherId == course.TeacherId);
            if (!teacherExists)
                return BadRequest($"Teacher with Id {course.TeacherId} does not exist.");

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.CourseId)
                return BadRequest("Course Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null)
                return NotFound($"Course with Id {id} not found.");

            var teacherExists = await _context.Teachers.AnyAsync(t => t.TeacherId == course.TeacherId);
            if (!teacherExists)
                return BadRequest($"Teacher with Id {course.TeacherId} does not exist.");

            existingCourse.CourseName = course.CourseName;
            existingCourse.Duration = course.Duration;
            existingCourse.TeacherId = course.TeacherId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound($"Course with Id {id} not found.");

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
