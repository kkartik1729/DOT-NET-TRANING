using _3Aug.Models;
using _3Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _3Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _service.GetCourse(id);

            if (course == null)
                return NotFound("Course not found");

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post(Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AddCourse(course);

            return Ok(new
            {
                Message = "Course added successfully",
                Course = course
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Course course)
        {
            if (id != course.Id)
                return BadRequest("Course Id mismatch");

            var existing = _service.GetCourse(id);

            if (existing == null)
                return NotFound("Course not found");

            _service.UpdateCourse(course);

            return Ok(new
            {
                Message = "Course updated successfully",
                Course = course
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _service.GetCourse(id);

            if (course == null)
                return NotFound("Course not found");

            _service.DeleteCourse(id);

            return Ok(new
            {
                Message = "Course deleted successfully"
            });
        }
    }
}