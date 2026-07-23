using _23Jul2026.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _23Jul2026.Controllers
{
    public class HomeController : Controller
    {
        // GET: login 
        public IActionResult Index()
        {
            return View();
        }
        //POST: login 
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            // simple hardcore login 
            if (username == "admin" && password == "12345")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Index", "Product");
            }
            ViewBag.Message = "Invalid username or password";
            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
