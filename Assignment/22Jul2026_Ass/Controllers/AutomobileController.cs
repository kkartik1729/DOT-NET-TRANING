using AutomobileManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileManagementSystem.Controllers
{
    public class AutomobileController : Controller
    {
        private const string RegisteredFlagKey = "AutomobileRegistered";

        // GET: /Automobile/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new Automobile());
        }

        // POST: /Automobile/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Automobile automobile)
        {
            if (!ModelState.IsValid)
            {
                // Invalid data: redisplay the form with validation messages.
                return View(automobile);
            }

            // Mark registration as successful for this session so the
            // Manufacturer module is allowed to display its details.
            HttpContext.Session.SetString(RegisteredFlagKey, "true");

            return View("Success", automobile);
        }
    }
}
