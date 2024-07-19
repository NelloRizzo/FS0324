using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W7.D3.BusinessLayer;
using W7.D3.WebAuthenticationSample.Models;

namespace W7.D3.WebAuthenticationSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;

        public HomeController(ILogger<HomeController> logger, IMailService mailService) {
            _logger = logger;
            _mailService = mailService;
        }

        public IActionResult Index() {
            return View();
        }

        //[Authorize(Roles = "admin")]
        //[Authorize(Policy = Policies.IsAdmin)]
        [Authorize(Policy = Policies.AgeRequirements)]
        public IActionResult Privacy() {
            return View();
        }

        public IActionResult SendMail() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMail(EmailModel model) {
            _mailService.SendMail(model.Sender, model.Subject, model.Body);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
