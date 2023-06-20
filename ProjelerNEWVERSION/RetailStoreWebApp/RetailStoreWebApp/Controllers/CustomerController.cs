using Microsoft.AspNetCore.Mvc;

namespace RetailStoreWebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
