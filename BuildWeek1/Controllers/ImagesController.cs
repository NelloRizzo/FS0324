using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;
using BuildWeek1.Models;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace BuildWeek1.Controllers
{
    public class ImagesController : MvcBaseController
    {
        public static byte[] ScaleImage(byte[] imageBytes, int? width, int? height) {
            Image image = Image.Load(imageBytes);

            int newWidth = image.Width;
            int newHeight = image.Height;

            if (width.HasValue) {
                var r = 1.0 * width.Value / image.Width;
                newWidth = width.Value;
                newHeight = (int)(image.Height * r);
            }
            if (height.HasValue) {
                var r = 1.0 * height.Value / image.Height;
                newHeight = height.Value;
                newWidth = (int)(image.Width * r);
            }

            image.Mutate(x => x.Resize(newWidth, newHeight));

            using var ms = new MemoryStream();
            image.Save(ms, new PngEncoder());
            return ms.ToArray();
        }

        public ImagesController(DbContext dbContext, ILogger<MvcBaseController> logger) : base(dbContext, logger) { }

        public IActionResult Index() {
            return View(_dbContext.Images.ReadAll().OrderBy(i => i.Title));
        }
        public IActionResult GetImage(int id, [FromQuery] int? width, [FromQuery] int? height) {
            var image = _dbContext.Images.Read(id);
            if (image == null) return NotFound();
            return File(ScaleImage(image.Content, width, height), "image/png");
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
