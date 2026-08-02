using Microsoft.AspNetCore.Mvc;
using _30Jul2026_Ass.Data;
using _30Jul2026_Ass.Models;

namespace _30Jul2026_Ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        // POST: api/Department
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (DataStore.Departments.Any(d => d.Name.Trim().Equals(department.Name.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = $"Department name '{department.Name}' already exists." });
            }

            if (!string.IsNullOrWhiteSpace(department.Code) &&
                DataStore.Departments.Any(d => !string.IsNullOrWhiteSpace(d.Code) &&
                                                d.Code!.Trim().Equals(department.Code!.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = $"Department code '{department.Code}' already exists." });
            }

            department.Id = DataStore.NextDepartmentId;
            DataStore.Departments.Add(department);

            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        // GET: api/Department
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAllDepartments()
        {
            return Ok(DataStore.Departments);
        }

        // GET: api/Department/{id}
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            var department = DataStore.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound(new { message = $"Department with id {id} not found." });
            }
            return Ok(department);
        }

        // PUT: api/Department/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] Department updatedDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = DataStore.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound(new { message = $"Department with id {id} not found." });
            }

            if (DataStore.Departments.Any(d => d.Id != id &&
                    d.Name.Trim().Equals(updatedDepartment.Name.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = $"Department name '{updatedDepartment.Name}' already exists." });
            }

            if (!string.IsNullOrWhiteSpace(updatedDepartment.Code) &&
                DataStore.Departments.Any(d => d.Id != id &&
                                                !string.IsNullOrWhiteSpace(d.Code) &&
                                                d.Code!.Trim().Equals(updatedDepartment.Code!.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = $"Department code '{updatedDepartment.Code}' already exists." });
            }

            department.Name = updatedDepartment.Name;
            department.Code = updatedDepartment.Code;
            department.Status = updatedDepartment.Status;

            return Ok(department);
        }

        // DELETE: api/Department/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = DataStore.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound(new { message = $"Department with id {id} not found." });
            }

            bool hasEmployees = DataStore.Employees.Any(e => e.DepartmentId == id);
            if (hasEmployees)
            {
                return BadRequest(new { message = "Department cannot be deleted because employees are assigned to it." });
            }

            DataStore.Departments.Remove(department);
            return Ok(new { message = $"Department with id {id} deleted successfully." });
        }
    }
}
