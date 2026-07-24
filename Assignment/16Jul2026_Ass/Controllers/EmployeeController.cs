using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // In a real app this would come from a database via a service/repository.
        // Kept as static sample data here so the view has something to display.
        private static readonly List<Employee> Employees = new()
        {
            new Employee { EmployeeId = 1, Name = "Rahul Sharma",  Department = "IT",         Salary = 55000, Email = "rahul.sharma@company.com" },
            new Employee { EmployeeId = 2, Name = "Priya Verma",   Department = "HR",         Salary = 48000, Email = "priya.verma@company.com" },
            new Employee { EmployeeId = 3, Name = "Amit Kumar",    Department = "Finance",    Salary = 62000, Email = "amit.kumar@company.com" },
            new Employee { EmployeeId = 4, Name = "Sneha Iyer",    Department = "Marketing",  Salary = 51000, Email = "sneha.iyer@company.com" },
            new Employee { EmployeeId = 5, Name = "Vikram Singh",  Department = "IT",         Salary = 58000, Email = "vikram.singh@company.com" }
        };

        // GET: /Employee or /Employee/Index
        public IActionResult Index()
        {
            return View(Employees);
        }
    }
}
