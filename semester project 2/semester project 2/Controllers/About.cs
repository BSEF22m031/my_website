using Microsoft.AspNetCore.Mvc;

namespace semester_project_2.Controllers
{
    public class About : Controller
    {
        public IActionResult aboutUs()
        {
            return View();
        }
    }
}
