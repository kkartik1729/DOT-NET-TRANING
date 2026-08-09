using _3Aug.Models;
using _3Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _3Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
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
            var student = _service.GetStudent(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddStudent(student);

            return Ok(new
            {
                Message = "Student added successfully",
                Student = student
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Student Id mismatch");
            }

            var existingStudent = _service.GetStudent(id);

            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }

            _service.UpdateStudent(student);

            return Ok(new
            {
                Message = "Student updated successfully",
                Student = student
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _service.GetStudent(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            _service.DeleteStudent(id);

            return Ok(new
            {
                Message = "Student deleted successfully"
            });
        }
    }
}