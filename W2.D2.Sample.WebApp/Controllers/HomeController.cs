using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W2.D2.Sample.Library.Services;
using W2.D2.Sample.WebApp.Models;

namespace W2.D2.Sample.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICvService _cvService;

        public HomeController(ILogger<HomeController> logger, ICvService service) {
            _logger = logger;
            _cvService = service;
        }

        public IActionResult Index() {
            var cv = _cvService.CreaCv();
            return View(cv);
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Info() {
            _cvService.AggiungiInformazioniPersonali(
                new W2.D2.Sample.Library.InformazioniPersonali {
                    Email = "archimede@paperopoli.com",
                    Phone = "31415926",
                    Name = "Archimede",
                    Surname = "Pitagorico"
                });
            return RedirectToAction("Index");
        }

        public IActionResult Exp() {
            _cvService.AggiungiEsperienza(
                new W2.D2.Sample.Library.Esperienza {
                    Al = DateOnly.FromDateTime(DateTime.Now),
                    Dal = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                    Azienda = "Personale",
                    Compiti = "Tuttofare",
                    Descrizione = "Facevo tutto io",
                    JobTitle = "Eccellenza"
                });
            return RedirectToAction("Index");
        }
        public IActionResult Study() {
            _cvService.AggiungiTitoloStudio(
                        new W2.D2.Sample.Library.TitoloDiStudio {
                            Al = new DateOnly(1999, 1, 1),
                            Dal = new DateOnly(1997, 1, 1),
                            Istituto = "Istituto Superiore",
                            Qualifica = "Diploma",
                            Tipo = "Scuola"
                        });
            _cvService.AggiungiTitoloStudio(
                new W2.D2.Sample.Library.TitoloDiStudio {
                    Al = new DateOnly(2004, 1, 1),
                    Dal = new DateOnly(2000, 1, 1),
                    Istituto = "Università",
                    Qualifica = "Laurea",
                    Tipo = "Università"
                });
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
