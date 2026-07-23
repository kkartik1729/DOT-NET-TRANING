using _23Jul2026.Models;
using _23Jul2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23Jul2026.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Index", "Home");
            }

            List<Product> products = new List<Product>()
            {
                new Product { id = 1, Name = "Laptop", Price = 78000 },
                new Product { id = 2, Name = "Mouse", Price = 900 },
                new Product { id = 3, Name = "Keyboard", Price = 1500 },
                new Product { id = 4, Name = "Monitor", Price = 12000 }
            };

            return View(products);
        }
    }
}