using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using weblab_4.Models;

namespace weblab_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult from(int id, string name, float price)
        {
            return View();
        }

        public IActionResult getProductDetail()
        {
            Product newproduct = new Product();
            object products;
            ViewBag.products = newproduct.getProduct();
            //ViewBag.products1 = products;
            return View(ViewBag.products);
        }
        /*[HttpGet]
        public IActionResult Productform(string username, string email)
        {


            return View();
        }*/
        [HttpPost]
        public IActionResult Productform(string username, string email)
        {
           /* string a;
            if(!email.EndsWith("@gmail.com"))
            {
                a = "wrong email";
                ViewBag.b = a;
            }*/
            
            return View();
        }
        public IActionResult homeproductdetails()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                title = "product1", 
                Items = new List<string> { "apple", "mango" }
            };

            return View(homeViewModel); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
