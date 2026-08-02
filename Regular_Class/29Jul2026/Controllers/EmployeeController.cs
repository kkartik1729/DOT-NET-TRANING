using _29Jul2026.Models;
using _29Jul2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace _29Jul2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;

        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.GetEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _services.GetEmployee(id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpGet("name/{name}")]
        public IActionResult Get(string name)
        {
            var emp = _services.GetEmployee(name);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            _services.AddEmployee(employee);

            return Ok(employee);
        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            var emp = _services.UpdateEmployee(employee);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _services.DeleteEmployee(id);

            if (!result)
                return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}