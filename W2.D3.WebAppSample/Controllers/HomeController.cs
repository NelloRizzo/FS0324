using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W2.D3.WebAppSample.Models;

namespace W2.D3.WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ShowDataForm() {
            var person = new Person();
            return View(person);
        }

        [HttpPost]
        public IActionResult HandleForm(Person p) {
            return View(p);
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Lista() {

            var list = new List<Person>() {
                new Person { FirstName = "Archimede", LastName="Pitagorico"},
                new Person { FirstName = "Paperon", LastName="De' Paperoni"},
                new Person{FirstName = "Pico", LastName = "De' Paperis"} 
            };
            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
