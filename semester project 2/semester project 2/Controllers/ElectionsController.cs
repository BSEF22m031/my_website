using Microsoft.AspNetCore.Mvc;

namespace semester_project_2.Controllers
{
    public class ElectionsController : Controller
    {
        public IActionResult elections()
        {
            return View();
        }
    }
}
