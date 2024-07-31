using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W9.D3.Samples.BusinessLayer;
using W9.D3.Samples.Models;

namespace W9.D3.Samples.Controllers
{
    public enum ShowType {
        People = 1, // per visualizzare persone
        Companies = 2, // per visualizzare aziende
        All = 3 // per visualizzare tutto
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;

        public HomeController(IContactService contactService, ILogger<HomeController> logger) {
            _logger = logger;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index([FromQuery] ShowType type = ShowType.All) {
            if (type == ShowType.All)
                return View(await _contactService.GetAllAsync());
            if (type == ShowType.Companies)
                return View(await _contactService.GetCompaniesAsync());
            return View(await _contactService.GetPeopleAsync());
        }

        public IActionResult AddPerson() {
            return View();
        }

        public IActionResult AddCompany() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPerson(PersonModel model) {
            if (ModelState.IsValid) {
                await _contactService.AddPersonAsync(model.FirstName, model.LastName);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyModel model) {
            if (ModelState.IsValid) {
                await _contactService.AddCompanyAsync(model.Name);
                return RedirectToAction("Index");
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
