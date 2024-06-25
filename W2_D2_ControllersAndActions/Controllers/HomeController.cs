using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using W2_D2_ControllersAndActions.Models;

namespace W2_D2_ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment e) {
            _logger = logger;
            _hostingEnvironment = e;
        }

        // https://servername:port/Home/Index
        public IActionResult Index() {
            var u = new { Name = User.Identity?.Name ?? "Anonimo" };
            //return Json(u);
            //return Redirect("/Home/Privacy");
            return RedirectToAction("Privacy");
        }

        // https://servername:port/Home/Privacy
        //public async Task<IActionResult> Privacy() {
        public IActionResult Privacy() {
            //var host = Request.Host;
            //await Response.WriteAsync($"<html><body>Hello user from {host}</body></html>");
            return View();
        }

        public IActionResult File() {
            // E:\Codice\FS0324\W2_D2_ControllersAndActions\wwwroot\files\output.pdf
            var file = System.IO.File.ReadAllBytes(Path.Combine(_hostingEnvironment.WebRootPath, "files/output.pdf"));
            var fileName = "Linq.pdf";
            return File(file, "application/pdf", fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
