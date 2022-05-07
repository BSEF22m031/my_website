using Microsoft.AspNetCore.Mvc;

namespace semester_project_2.Controllers
{
    public class VotersController : Controller
    {
        public IActionResult voters()
        {
            return View();
        }
    }
}
