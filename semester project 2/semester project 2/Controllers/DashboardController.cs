using Microsoft.AspNetCore.Mvc;

namespace semester_project_2.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult dashboard()
        {
            return View();
        }
    }
}
