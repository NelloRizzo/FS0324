using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Controllers
{
    public class AdminController : MvcBaseController
    {
        public AdminController(DbContext context, ILogger<AdminController> logger) : base(context, logger) { }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Products() {
            return View(_dbContext.Products.ReadAll());
        }

        public IActionResult ProductsCreate() {
            return View();
        }
        [HttpPost]
        public IActionResult ProductsCreate(ProductEntity model) {
            _dbContext.Products.Create(model);
            return RedirectToAction(nameof(Products));
        }
    }
}
