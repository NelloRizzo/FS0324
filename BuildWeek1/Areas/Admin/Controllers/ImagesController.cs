using BuildWeek1.BusinessLayer;
using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;
using BuildWeek1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImagesController : MvcBaseController
    {
        private readonly IThumbnailService _imageService;
        public ImagesController(IThumbnailService imageService, DbContext dbContext, ILogger<MvcBaseController> logger) : base(dbContext, logger) {
            _imageService = imageService;
        }

        public IActionResult Index() {
            return View(_dbContext.Images.ReadAll().OrderBy(i => i.Title));
        }
        public IActionResult Thumbnail(int id, [FromQuery] int? width, [FromQuery] int? height) {
            return File(_imageService.Thumbnail(id, width, height), "image/png");
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ImageInputViewModel model) {
            using var ms = new MemoryStream();
            model.Image.CopyTo(ms);
            _dbContext.Images.Create(new ImageEntity {
                Content = ms.ToArray(),
                MimeType = model.Image.ContentType,
                Description = model.Description,
                Title = model.Title
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
