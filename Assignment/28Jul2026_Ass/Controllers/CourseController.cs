using CourseRegistrationSystem.Models;
using CourseRegistrationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        // ICourseService is injected via the constructor (Dependency Injection),
        // registered in Program.cs.
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>View all available courses.</summary>
        // GET: api/course
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAll()
        {
            return Ok(_courseService.GetAll());
        }

        /// <summary>View a single course by Id.</summary>
        // GET: api/course/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = _courseService.GetById(id);
            if (course == null)
                return NotFound($"Course with Id {id} was not found.");

            return Ok(course);
        }

        /// <summary>Register for a new course.</summary>
        // POST: api/course
        [HttpPost]
        public ActionResult<Course> Register([FromBody] Course course)
        {
            var registered = _courseService.Register(course);
            return CreatedAtAction(nameof(GetById), new { id = registered.Id }, registered);
        }

        /// <summary>Update the duration of an existing course.</summary>
        // PUT: api/course/{id}/duration
        [HttpPut("{id:int}/duration")]
        public IActionResult UpdateDuration(int id, [FromBody] UpdateDurationDto dto)
        {
            bool updated = _courseService.UpdateDuration(id, dto.duration);
            if (!updated)
                return NotFound($"Course with Id {id} was not found.");

            return Ok(_courseService.GetById(id));
        }

        /// <summary>Cancel (remove) a course.</summary>
        // DELETE: api/course/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Cancel(int id)
        {
            bool cancelled = _courseService.Cancel(id);
            if (!cancelled)
                return NotFound($"Course with Id {id} was not found.");

            return Ok($"Course with Id {id} was cancelled.");
        }
    }
}
