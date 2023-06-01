using Microsoft.AspNetCore.Mvc;
using P1_HangfireProject.Core.Entities.Models;
using System.Diagnostics;

namespace P1_HangfireProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Hangfire()
        {
            return Redirect("/hangfire");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}