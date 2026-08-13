using AutomobileManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileManagementSystem.Controllers
{
    public class ManufacturerController : Controller
    {
        private const string RegisteredFlagKey = "AutomobileRegistered";

        private static readonly List<Manufacturer> Manufacturers = new()
        {
            new Manufacturer { Name = "Tata Motors",     Country = "India",   ContactNumber = "9876543210", EmailAddress = "contact@tatamotors.com" },
            new Manufacturer { Name = "Maruti Suzuki",   Country = "India",   ContactNumber = "9876543211", EmailAddress = "contact@marutisuzuki.com" },
            new Manufacturer { Name = "Toyota",          Country = "Japan",   ContactNumber = "9876543212", EmailAddress = "contact@toyota.com" },
            new Manufacturer { Name = "Ford",            Country = "USA",     ContactNumber = "9876543213", EmailAddress = "contact@ford.com" }
        };
        public IActionResult Index()
        {
            bool isRegistered = HttpContext.Session.GetString(RegisteredFlagKey) == "true";

            if (!isRegistered)
            {
                
                TempData["ManufacturerBlockedMessage"] =
                    "Please complete automobile registration before viewing manufacturer details.";
                return RedirectToAction("Register", "Automobile");
            }

            return View(Manufacturers);
        }
    }
}
