using InputValidation.Models;
using InputValidation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InputValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICityService _cityService;
        private readonly IFiscalCodeService _fiscalCodeService;

        public HomeController(ILogger<HomeController> logger, ICityService cityService, IFiscalCodeService fiscalCodeService) {
            _logger = logger;
            _cityService = cityService;
            _fiscalCodeService = fiscalCodeService;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult FiscalCode() {
            return View(new PersonalDataViewModel { BirthOfCity = "", FirstName = "", LastName = "", Gender = 'F' });
        }

        [HttpPost]
        public IActionResult FiscalCode(PersonalDataViewModel model) {
            // validazione lato server
            if (ModelState.IsValid) {
                try {
                    var city = _cityService.GetCityByName(model.BirthOfCity);
                    var fc = _fiscalCodeService.GenerateFiscalCode(new Services.Dto.PersonalDataDto {
                        BirthCity = city,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Birthday = model.Birthday,
                        Gender = model.Gender == 'F' ? Services.Dto.Gender.Female : Services.Dto.Gender.Male
                    });
                    ViewBag.FiscalCode = fc;
                }
                catch (Exception ex) {
                    ModelState.AddModelError("unattended_exception", "Si è verificato un problema nel calcolo");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // verifica il token rilasciato dalla GET
        public IActionResult HandleInputModel([Bind("Name")] InputModel model) {
            return View("HandleInputModelResponse", model);
        }
        public IActionResult HandleInputModel() { // chiamata GET - produce il token antiforgery
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
