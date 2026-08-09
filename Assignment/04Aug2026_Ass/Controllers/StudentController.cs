using _04Aug2026_Ass.Models;
using _04Aug2026_Ass.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _04Aug2026_Ass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentsController(IStudentService service)
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
            var student = service.GetStudent(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddS(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddStudent(student);

            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateS(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = service.GetStudent(id);

            if (existing == null)
            {
                return NotFound();
            }

            service.UpdateStudent(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = service.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            service.DeleteStudent(id);

            return Ok("Student Deleted Successfully");
        }
    }
}
