using Microsoft.AspNetCore.Mvc;

namespace weblab_4.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Productform()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Productform(string FoodItem, int quantity)
        {
            /*string data;
            if (string.IsNullOrWhiteSpace(FoodItem))
            {
                data = "no data found";
            }
            else
            {
                data = "data found";
            }
            ViewBag.a = data;
            return View(ViewBag.a);*/
            return View();
        }
    }
}
