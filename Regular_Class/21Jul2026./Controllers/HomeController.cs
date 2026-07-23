using Microsoft.AspNetCore.Mvc;
using _16Jul2026.Models;

namespace _16Jul2026.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    Id = 1,
                    Name = "Kartik",
                    Age = 20,
                    Gender = "Male",
                    Qualification = "B.E CSE",
                    Course = ".NET"
                },
                new Student
                {
                    Id = 2,
                    Name = "Rahul",
                    Age = 21,
                    Gender = "Male",
                    Qualification = "B.Tech",
                    Course = "Java"
                },
                new Student
                {
                    Id = 3,
                    Name = "Priya",
                    Age = 20,
                    Gender = "Female",
                    Qualification = "B.Sc",
                    Course = "Python"
                }
            };

            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}