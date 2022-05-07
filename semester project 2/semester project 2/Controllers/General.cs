using Microsoft.AspNetCore.Mvc;

namespace semester_project_2.Controllers
{
    public class General : Controller
    {
        public IActionResult learnMore()
        {
            return View();
        }
    }
}
