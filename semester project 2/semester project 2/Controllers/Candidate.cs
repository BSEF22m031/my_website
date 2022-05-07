using Microsoft.AspNetCore.Mvc;

namespace semester_project_2.Controllers
{
    public class Candidate : Controller
    {
        public IActionResult Candidates()
        {
            return View();
        }
    }
}
