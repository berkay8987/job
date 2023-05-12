using LifecyclesExample.Interfaces;
using LifecyclesExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LifecyclesExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly ISingeltonService _singletonService1;
        private readonly ISingeltonService _singletonService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;

        public HomeController(ILogger<HomeController> logger, ITransientService transientService1, 
            ITransientService transientService2, ISingeltonService singletonService1, 
            ISingeltonService singletonService2, IScopedService scopedService1,
            IScopedService scopedService2)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;

            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;

            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
        }

        public IActionResult Index()
        {
            ViewBag.TransientService1 = _transientService1.GetId();
            ViewBag.TransientService2 = _transientService2.GetId();

            ViewBag.SingletonService1 = _singletonService1.GetId();
            ViewBag.SingletonService2 = _singletonService2.GetId();

            ViewBag.ScopedService1 = _scopedService1.GetId();
            ViewBag.ScopedService2 = _scopedService2.GetId();

            return View();
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