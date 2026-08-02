using Microsoft.AspNetCore.Mvc;
using _30Jul2026_Ass.Data;
using _30Jul2026_Ass.Models;

namespace _30Jul2026_Ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // POST: api/Employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = DataStore.Departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
            if (department == null)
            {
                return BadRequest(new { message = $"Department with id {employee.DepartmentId} does not exist." });
            }

            if (department.Status == DepartmentStatus.Inactive)
            {
                return BadRequest(new { message = $"Cannot assign employee to inactive department '{department.Name}'." });
            }

            if (DataStore.Employees.Any(e => e.Email.Trim().Equals(employee.Email.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = $"An employee with email '{employee.Email}' already exists." });
            }

            employee.EmployeeId = DataStore.NextEmployeeId;
            DataStore.Employees.Add(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(DataStore.Employees);
        }

        // GET: api/Employee/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = DataStore.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound(new { message = $"Employee with id {id} not found." });
            }
            return Ok(employee);
        }

        // PUT: api/Employee/{id}
        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = DataStore.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound(new { message = $"Employee with id {id} not found." });
            }

            var department = DataStore.Departments.FirstOrDefault(d => d.Id == updatedEmployee.DepartmentId);
            if (department == null)
            {
                return BadRequest(new { message = $"Department with id {updatedEmployee.DepartmentId} does not exist." });
            }

            if (department.Status == DepartmentStatus.Inactive)
            {
                return BadRequest(new { message = $"Cannot assign employee to inactive department '{department.Name}'." });
            }

            if (DataStore.Employees.Any(e => e.EmployeeId != id &&
                    e.Email.Trim().Equals(updatedEmployee.Email.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = $"An employee with email '{updatedEmployee.Email}' already exists." });
            }

            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.MobileNumber = updatedEmployee.MobileNumber;
            employee.DateOfBirth = updatedEmployee.DateOfBirth;
            employee.Gender = updatedEmployee.Gender;
            employee.Salary = updatedEmployee.Salary;
            employee.DateOfJoining = updatedEmployee.DateOfJoining;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            employee.Designation = updatedEmployee.Designation;
            employee.Status = updatedEmployee.Status;

            return Ok(employee);
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = DataStore.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound(new { message = $"Employee with id {id} not found." });
            }

            DataStore.Employees.Remove(employee);
            return Ok(new { message = $"Employee with id {id} deleted successfully." });
        }

        // GET: api/Employee/search?name=&departmentId=&email=&employeeId=&status=
        [HttpGet("search")]
        public ActionResult<IEnumerable<Employee>> SearchEmployees(
            [FromQuery] string? name,
            [FromQuery] int? departmentId,
            [FromQuery] string? email,
            [FromQuery] int? employeeId,
            [FromQuery] EmployeeStatus? status)
        {
            var query = DataStore.Employees.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(e =>
                    e.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                    e.LastName.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (departmentId.HasValue)
            {
                query = query.Where(e => e.DepartmentId == departmentId.Value);
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(e => e.Email.Contains(email, StringComparison.OrdinalIgnoreCase));
            }

            if (employeeId.HasValue)
            {
                query = query.Where(e => e.EmployeeId == employeeId.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(e => e.Status == status.Value);
            }

            return Ok(query.ToList());
        }

        // GET: api/Employee/by-department/{departmentId}
        [HttpGet("by-department/{departmentId}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            var department = DataStore.Departments.FirstOrDefault(d => d.Id == departmentId);
            if (department == null)
            {
                return NotFound(new { message = $"Department with id {departmentId} not found." });
            }

            var employees = DataStore.Employees.Where(e => e.DepartmentId == departmentId).ToList();
            return Ok(employees);
        }
    }
}
