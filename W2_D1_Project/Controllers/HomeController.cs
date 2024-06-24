using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W2_D1_Project.Models;

namespace W2_D1_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            var list = new List<PersonModel> {
                new PersonModel{ FirstName="Archimede", LastName="Pitagorico"},
                new PersonModel{FirstName="Paperon", LastName="De' Paperoni"},
                new PersonModel{FirstName = "Pico", LastName="De' Paperis"}
            };
            return View(list);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
