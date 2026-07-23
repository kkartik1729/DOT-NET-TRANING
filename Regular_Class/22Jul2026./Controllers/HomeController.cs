using _22Jul2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22Jul2026.Controllers
{
    public class HomeController : Controller
    {
        // Product

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            if (ModelState.IsValid)
            {
                return Content($"Product: {product.Name}, Price: {product.Price}, Category: {product.Category}, Stock: {product.Stock}");
            }

            return View(product);
        }

        // Stationary

        public IActionResult Stationary()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Stationary(Stationary stationary)
        {
            if (ModelState.IsValid)
            {
                return Content($"Item Name: {stationary.ItemName}, Price: {stationary.Price}, Brand: {stationary.Brand}, Quantity: {stationary.Quantity}");
            }

            return View(stationary);
        }
    }
}