using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Lab_07.Models;

namespace Web_Lab_07.Controllers
{
    public class PricingController : Controller
    {
        public ActionResult Index()
        {
            var plans = new List<PricingPlan>
            {
                new PricingPlan { Title = "Basic", Price = "$10/month", Features = "Feature 1, Feature 2", IsPopular = false, ButtonText = "Get Started", ButtonClass = "btn-outline-primary" },
                new PricingPlan { Title = "Advanced", Price = "$20/month", Features = "Feature 1, Feature 2, Feature 3", IsPopular = true, ButtonText = "Get Started", ButtonClass = "btn-outline-success" },
                new PricingPlan { Title = "Pro", Price = "$30/month", Features = "Feature 1, Feature 2, Feature 3, Feature 4", IsPopular = false, ButtonText = "Get Started", ButtonClass = "btn-outline-secondary" }
            };
            return View(plans);
        }
    }
}
