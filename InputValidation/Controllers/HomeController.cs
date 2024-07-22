using InputValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InputValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult FiscalCode() {
            return View(new PersonalDataViewModel { BirthCity = "", FirstName = "", LastName = "", Gender = 'F' });
        }

        [HttpPost]
        public IActionResult FiscalCode(PersonalDataViewModel model) {
            // validazione lato server
            if (ModelState.IsValid) {
                ModelState.AddModelError("custom_validation_error", "Ho riscontrato un problema nei dati validandoli sul server");
                ModelState.AddModelError(nameof(PersonalDataViewModel.BirthCity), "La città non esiste");
            }
            return View(model);
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
