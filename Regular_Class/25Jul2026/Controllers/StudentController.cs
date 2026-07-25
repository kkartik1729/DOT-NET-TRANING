using _25Jul2026.Model;
using Microsoft.AspNetCore.Mvc;

namespace _25Jul2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new()
        {
            new Student()
            {
                Id = 1,
                Name = "Kartik",
                Age = 18,
                Department = "CSE"
            },

            new Student()
            {
                Id = 2,
                Name = "Ram",
                Age = 19,
                Department = "IT"
            },

            new Student()
            {
                Id = 3,
                Name = "Pratik",
                Age = 20,
                Department = "EXTC"
            }
        };

        // GET : api/student
        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(students);
        }

        // GET : api/student/2
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id },
                student
            );
        }

        [HttpPut("{id}")] // edit or modify existing student data based on id
        public IActionResult UpdateStudent(int id, Student updateStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            student.Age = updateStudent.Age;

            return NoContent();
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();   // 404

            students.Remove(student);

            return NoContent();      // 204
        }
    }
}