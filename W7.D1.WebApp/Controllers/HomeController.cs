using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W7.D1.WebApp.Models;

namespace W7.D1.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public void MyMethod(string p1, int p2 = -2, int p3 = 10) {

        }
        public IActionResult Index(string? id = "it") {
            //MyMethod("P1", 0, 1);
            //MyMethod(p2: -3, p1: "Pippo", p3: 10);
            //MyMethod("Prova");
            //MyMethod("Prova", 10);
            //MyMethod("Prova", 10, 100);
            //MyMethod("Prova", p3: 50);
            ViewBag.Language = id;
            return View();
        }

        public IActionResult Privacy() {
            //Index();
            //Index("fr");
            //Index(id: "de");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
