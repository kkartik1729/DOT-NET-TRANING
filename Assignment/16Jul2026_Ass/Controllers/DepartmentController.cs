using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private static readonly List<Department> Departments = new()
        {
            new Department { DepartmentId = 1, Name = "IT",        DepartmentHead = "Anjali Mehta", HeadContact = "9876543210", HeadEmail = "anjali.mehta@company.com" },
            new Department { DepartmentId = 2, Name = "HR",        DepartmentHead = "Rohit Malhotra", HeadContact = "9876543211", HeadEmail = "rohit.malhotra@company.com" },
            new Department { DepartmentId = 3, Name = "Finance",   DepartmentHead = "Kavita Rao",   HeadContact = "9876543212", HeadEmail = "kavita.rao@company.com" },
            new Department { DepartmentId = 4, Name = "Marketing", DepartmentHead = "Suresh Nair",  HeadContact = "9876543213", HeadEmail = "suresh.nair@company.com" }
        };
        public IActionResult Index()
        {
            return View(Departments);
        }
    }
}
