using Microsoft.AspNetCore.Mvc;
using SemesterProject.Models;
using System.Diagnostics;

namespace SemesterProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            ViewBag.Username = username;
            ViewBag.Password = password;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult role()
        {

            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string username, string password, string email, string idNumber, string phoneNumber, string role)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = username,
                    Password = password,  
                    Email = email,
                    IdNumber = idNumber,
                    PhoneNumber = phoneNumber,
                    Role = role
                };

               
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
