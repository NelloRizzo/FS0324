using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W3.D4.DailyProject.Models;
using W3.D4.DailyProject.Services;

namespace W3.D4.DailyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImpiegatoService _service;

        private void Populate() {
            Random rnd = new Random();
            Enumerable.Range(0, 100).Select(
                n => new Impiegato {
                    CodiceFiscale = "XXXXXXXXXXXXXXXX",
                    Cognome = $"Cognome {n}",
                    DetrazioneFiscale = rnd.NextDouble() > .5,
                    Eta = 18 + rnd.Next(50),
                    Nome = $"Nome {n}",
                    RedditoMensile = rnd.Next(1000, 10000)
                }).ToList()
                .ForEach(i => _service.AssumiImpiegato(i,
                    new Impiego { Assunzione = DateTime.Now, TipoImpiego = "Tipo impiego" }));
        }
        public HomeController(ILogger<HomeController> logger, IImpiegatoService service) {
            _logger = logger;
            _service = service;

            if (!_service.GetAll(0).Any()) Populate();
        }

        public IActionResult Index() {
            return View();
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
