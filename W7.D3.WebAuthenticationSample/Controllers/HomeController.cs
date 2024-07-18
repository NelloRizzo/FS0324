using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W7.D3.WebAuthenticationSample.Models;

namespace W7.D3.WebAuthenticationSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
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

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
