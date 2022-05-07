using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_lab_08.Models;

namespace web_lab_08.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

