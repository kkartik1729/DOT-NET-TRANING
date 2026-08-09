using _04Aug2026_Ass.Models;
using _04Aug2026_Ass.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _04Aug2026_Ass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService service;

        public CoursesController(ICourseService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var course = service.GetCourse(id);

            if (course == null)
            {
                return NotFound("Course not found");
            }

            return Ok(course);
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddCourse(course);

            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = service.GetCourse(id);

            if (existing == null)
            {
                return NotFound();
            }

            service.UpdateCourse(course);

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = service.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            service.DeleteCourse(id);

            return Ok("Course Deleted Successfully");
        }
    }
}
