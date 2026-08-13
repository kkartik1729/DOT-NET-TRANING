using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private const string RegisteredFlagKey = "EmployeeRegistered";
        private static readonly List<Department> Departments = new()
        {
            new Department { Name = "IT",        DepartmentHead = "Anjali Mehta",   HeadContactNumber = "9876543210", HeadEmail = "anjali.mehta@company.com" },
            new Department { Name = "HR",        DepartmentHead = "Rohit Malhotra", HeadContactNumber = "9876543211", HeadEmail = "rohit.malhotra@company.com" },
            new Department { Name = "Finance",   DepartmentHead = "Kavita Rao",     HeadContactNumber = "9876543212", HeadEmail = "kavita.rao@company.com" },
            new Department { Name = "Marketing", DepartmentHead = "Suresh Nair",    HeadContactNumber = "9876543213", HeadEmail = "suresh.nair@company.com" }
        };

        public IActionResult Index()
        {
            bool isRegistered = HttpContext.Session.GetString(RegisteredFlagKey) == "true";

            if (!isRegistered)
            {
                
                TempData["DepartmentBlockedMessage"] =
                    "Please complete employee registration before viewing department details.";
                return RedirectToAction("Register", "Employee");
            }

            return View(Departments);
        }
    }
}
