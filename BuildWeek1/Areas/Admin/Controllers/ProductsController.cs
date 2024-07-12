﻿using BuildWeek1.BusinessLayer;
using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;
using BuildWeek1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : MvcBaseController
    {
        private readonly IProductService _productService;
        public ProductsController(
            // TODO: mantenuta per compatibilità con i vecchi controllers che usano ancora il contesto dati direttamente
            DbContext dbContext,
            ILogger<MvcBaseController> logger,
            IProductService productService) : base(dbContext, logger) {
            _productService = productService;
        }

        public IActionResult Index([FromQuery] int page = 0, [FromQuery] int pageSize = 5) {
            return View(_productService.GetPage(page, pageSize));
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
