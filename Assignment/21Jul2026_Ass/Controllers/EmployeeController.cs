using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private const string RegisteredFlagKey = "EmployeeRegistered";
        private const string RegisteredNameKey = "RegisteredEmployeeName";
        private const string RegisteredDeptKey = "RegisteredEmployeeDepartment";

        // GET: /Employee/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new Employee());
        }

        // POST: /Employee/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // Invalid data: redisplay the form with validation messages.
                return View(employee);
            }

            // Mark registration as successful for this session so the
            // Department module is allowed to display its details.
            HttpContext.Session.SetString(RegisteredFlagKey, "true");
            HttpContext.Session.SetString(RegisteredNameKey, employee.Name);
            HttpContext.Session.SetString(RegisteredDeptKey, employee.Department);

            return View("Success", employee);
        }
    }
}
