using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;
using BuildWeek1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Controllers
{
    public class ProductsController : MvcBaseController
    {
        public ProductsController(DbContext dbContext, ILogger<MvcBaseController> logger) : base(dbContext, logger) { }

        public IActionResult Index() {
            return View(_dbContext.Products.ReadAll());
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductInputViewModel model) {
            using var ms = new MemoryStream();
            model.Cover.CopyTo(ms);
            var img = _dbContext.Images.Create(new ImageEntity {
                Content = ms.ToArray(),
                MimeType = model.Cover.ContentType,
                Title = model.Title
            });
            _dbContext.Products.Create(new ProductEntity {
                CoverId = img.Id,
                Description = model.Description,
                Price = model.Price,
                Title = model.Title
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            _dbContext.Products.Delete(id);
            return Json("Ok");
        }
    }
}
