using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W7.D3.BusinessLayer;
using W7.D3.BusinessLayer.Data;

namespace W7.D3.WebAuthenticationSample.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ILogger<CustomersController> logger;
        public CustomersController(ICustomerService customer, ILogger<CustomersController> logger) {
            this.customerService = customer;
            this.logger = logger;
        }

        public IActionResult Index() {
            return View(customerService.GetAll());
        }

        public IActionResult CreateCompany() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCompany(CompanyDto company) {
            customerService.RegisterCompany(company);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreatePerson() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePerson(PersonDto person) {
            customerService.RegisterPerson(person);
            return RedirectToAction(nameof(Index));
        }
    }
}
