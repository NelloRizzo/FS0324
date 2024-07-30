using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using W9.D2.EFCRUD.DataLayer;
using W9.D2.EFCRUD.DataLayer.Entities;
using W9.D2.EFCRUD.Models;

namespace W9.D2.EFCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _ctx;

        public HomeController(BlogDbContext dbContext, ILogger<HomeController> logger) {
            _logger = logger;
            _ctx = dbContext;
        }

        public async Task<IActionResult> Index([FromQuery] string contains = "") {
            ViewBag.Contains = contains;
            var list = await _ctx.Authors // LINQ To Entities
                .Where(author => author.FriendlyName.Contains(contains))
                .Select(author => author.FriendlyName)
                .Select(s => s.ToUpper())
                .ToListAsync()
                ;
            return View(new IndexViewModel { Authors = list });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAuthor(IndexViewModel model) {
            if (ModelState.IsValid) {
                var author = new Author {
                    Email = model.Email!,
                    FriendlyName = model.FriendlyName!,
                    Password = model.Password!
                };
                _ctx.Authors.Add(author);
                await _ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", model);
        }

        public async Task<ActionResult> DeleteAuthor(string id) {
            var author = await _ctx.Authors.FirstOrDefaultAsync(a => a.FriendlyName.ToUpper() == id);
            if (author == null) return RedirectToAction(nameof(Index));
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAuthor(int id) {
            var author = await _ctx.Authors.SingleAsync(a => a.Id == id);
            _ctx.Authors.Remove(author);
            await _ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Articles(string id) {
            var author = await _ctx.Authors
                //.Include(a => a.Articles)
                .FirstOrDefaultAsync(a => a.FriendlyName.ToUpper() == id);
            return View(author!.Articles);
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
