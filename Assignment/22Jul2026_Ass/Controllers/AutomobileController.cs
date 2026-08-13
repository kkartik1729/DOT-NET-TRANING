using AutomobileManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileManagementSystem.Controllers
{
    public class AutomobileController : Controller
    {
        private const string RegisteredFlagKey = "AutomobileRegistered";

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Automobile());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Automobile automobile)
        {
            if (!ModelState.IsValid)
            {
                return View(automobile);
            }

            HttpContext.Session.SetString(RegisteredFlagKey, "true");

            return View("Success", automobile);
        }
    }
}
