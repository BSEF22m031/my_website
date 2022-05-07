using Microsoft.AspNetCore.Mvc;

namespace semester_project_2.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult userManagement()
        {
            return View();
        }
    }
}
