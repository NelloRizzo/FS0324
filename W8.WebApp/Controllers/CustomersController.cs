using Microsoft.AspNetCore.Mvc;
using W8.Services.Dto;
using W8.Services.Exceptions;
using W8.Services.Interfaces;
using W8.WebApp.Models;

namespace W8.WebApp.Controllers
{
    public class CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
        : BaseController(logger)
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<IActionResult> Index(int page = 0, int pageSize = 50) {
            return View(await _customerService.GetPageAsync(page, pageSize));
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel model) {
            if (ModelState.IsValid) {
                try {
                    var customer = new CustomerDto {
                        City = model.City,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        FiscalCode = model.FiscalCode,
                        Province = model.Province,
                        Phone = model.Phone,
                        Mobile = model.Mobile,
                    };
                    await _customerService.SaveAsync(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (DataAlreadyPresentException ex) {
                    _logger.LogError(ex, "Violation of unique constraint");
                    ModelState.AddModelError("ServiceException", R.Exceptions.CustomerDuplicated);
                }
                catch (Exception ex) {
                    _logger.LogError(ex, "Unattended exception creating customer");
                    ModelState.AddModelError("ServiceException", R.Exceptions.Unattended);
                }
            }
            return View(model);
        }
    }
}
