using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private const string RegisteredFlagKey = "EmployeeRegistered";
        private const string RegisteredNameKey = "RegisteredEmployeeName";
        private const string RegisteredDeptKey = "RegisteredEmployeeDepartment";

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Employee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

       
            HttpContext.Session.SetString(RegisteredFlagKey, "true");
            HttpContext.Session.SetString(RegisteredNameKey, employee.Name);
            HttpContext.Session.SetString(RegisteredDeptKey, employee.Department);

            return View("Success", employee);
        }
    }
}
