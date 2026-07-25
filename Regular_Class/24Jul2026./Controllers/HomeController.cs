using _24Jul2026.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

public class HomeController : Controller
{
    //Get : login
    public ActionResult Index()
    {
        return View();
    }

    //Post : login
    [HttpPost]
    public ActionResult Index(Student student)
    {
        if (ModelState.IsValid)
        {
            if (student.Username == "admin" && student.Password == "123456")
            {
                HttpContext.Session.SetString("User", student.Username);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
        }

        return View(student);
    }

    public ActionResult Dashboard()
    {
        var user = HttpContext.Session.GetString("User");

        if (string.IsNullOrEmpty(user))
        {
            return RedirectToAction("Index");
        }

        ViewBag.User = user;

        return View();
    }

    public ActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}