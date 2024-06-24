using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W2_D1_DailyProjectV1;
using W2_D1_DailyProjectWeb.Models;

namespace W2_D1_DailyProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService) {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index() {
            return View(_productService.GetProducts());
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
