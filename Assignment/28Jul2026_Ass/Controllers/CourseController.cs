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
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAll()
        {
            return Ok(_courseService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = _courseService.GetById(id);
            if (course == null)
                return NotFound($"Course with Id {id} was not found.");

            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> Register([FromBody] Course course)
        {
            var registered = _courseService.Register(course);
            return CreatedAtAction(nameof(GetById), new { id = registered.Id }, registered);
        }

        [HttpPut("{id:int}/duration")]
        public IActionResult UpdateDuration(int id, [FromBody] UpdateDurationDto dto)
        {
            bool updated = _courseService.UpdateDuration(id, dto.duration);
            if (!updated)
                return NotFound($"Course with Id {id} was not found.");

            return Ok(_courseService.GetById(id));
        }

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
