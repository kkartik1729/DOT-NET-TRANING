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
                new Product { id = 1, Name = "Pen", Price = 10 },
                new Product { id = 2, Name = "Pencil", Price = 5 },
                new Product { id = 3, Name = "Notebook", Price = 40 },
                new Product { id = 4, Name = "Eraser", Price = 3 },
                new Product { id = 5, Name = "Ruler", Price = 8 },
                new Product { id = 6, Name = "Stapler", Price = 60 }
            };

            return View(products);
        }
    }
}