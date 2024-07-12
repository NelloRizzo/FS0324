using BuildWeek1.BusinessLayer;
using BuildWeek1.BusinessLayer.Dto;
using BuildWeek1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImagesController : MvcBaseController
    {
        private readonly IThumbnailService _thumbnailService;
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService, IThumbnailService thumbnailService, ILogger<MvcBaseController> logger) : base(logger) {
            _thumbnailService = thumbnailService;
            _imageService = imageService;
        }

        public IActionResult Index() {
            return View(_imageService.GetAll().OrderBy(i => i.Title));
        }
        public IActionResult Thumbnail(int id, [FromQuery] int? width, [FromQuery] int? height) {
            var image = _imageService.Get(id) ?? throw new FileNotFoundException();
            return File(_thumbnailService.Thumbnail(image.Content, width, height), "image/png");
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ImageInputViewModel model) {
            using var ms = new MemoryStream();
            model.Image.CopyTo(ms);
            _imageService.Save(new ImageDto {
                Content = ms.ToArray(),
                MimeType = model.Image.ContentType,
                Description = model.Description,
                Title = model.Title
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
