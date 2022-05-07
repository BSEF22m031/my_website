using Microsoft.AspNetCore.Mvc;

namespace web_lab_06.Controllers
{
    public class WellcomeController : Controller
    {
        [HttpPost]
        public IActionResult Index(string username)
        {
            ViewBag.X=username;
            return View();
        }
       

    }
}
