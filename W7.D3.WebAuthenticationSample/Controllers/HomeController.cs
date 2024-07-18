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
        private readonly IMailService mailService;

        public HomeController(IMailService mail, ILogger<HomeController> logger) {
            _logger = logger;
            mailService = mail;
        }

        [AllowAnonymous]
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
        public IActionResult SendMail(EmailModel model) {
            mailService.SendMail(model.Sender,
                model.Subject, $"Ci hai appena scritto quanto segue:\n {model.Body}");
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
