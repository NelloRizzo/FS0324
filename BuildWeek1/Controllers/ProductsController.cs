using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;
using BuildWeek1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Controllers
{
    public class ProductsController : MvcBaseController
    {
        public ProductsController(DbContext dbContext, ILogger<MvcBaseController> logger) : base(dbContext, logger) { }

        public IActionResult Index([FromQuery] int page = 0, [FromQuery] int pageSize = 5) {
            var count = _dbContext.Products.Count();
            var list = _dbContext.Products.ReadAll(page, pageSize);
            var pager = new Pager { Action = nameof(Index), PageIndex = page, PageSize = pageSize, TotalRecords = count };
            return View(new Page<ProductEntity> { Items = list, Pager = pager });
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
            try {
                _dbContext.Products.Delete(id);
                return Json("Ok");
            }
            catch (Exception) {
                return BadRequest();
            }
        }

        public IActionResult MvcDelete(int id) {
            var product = _dbContext.Products.Read(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult MvcDelete(ProductEntity model) {
            _dbContext.Products.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
