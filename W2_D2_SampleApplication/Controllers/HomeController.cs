using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W2_D2_SampleApplication.Models;
using W2_D2_SampleApplication.Services;

namespace W2_D2_SampleApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IProductService service, IWebHostEnvironment env) {
            _logger = logger;
            _productService = service;
            _env = env;
        }

        public IActionResult Index() {
            var categories = _productService.GetCategories();
            return View(categories);
        }

        public IActionResult Products(int id) {
            var categoryName = _productService.GetCategories().FirstOrDefault(c => c.Id == id).Name;
            var products = _productService.GetProducts(categoryName);
            return View(products);
        }

        public IActionResult ProductCard(int id) {
            var product = _productService.GetProduct(id);

            var file = System.IO.File.ReadAllText(Path.Combine(_env.WebRootPath, "files/ProductCard.txt"));
            file = file.Replace("#PRODOTTO", product.Name)
                .Replace("#CATEGORIA", product.Category.Name)
                .Replace("#DESCRIZIONE", product.Description);
            return File(System.Text.Encoding.UTF8.GetBytes(file), "text/plain", $"Scheda Prodotto {product.Name}.txt");
        }

        public IActionResult Image() {
            var file = System.IO.File.ReadAllBytes(Path.Combine(_env.WebRootPath, "files/http404.jpg"));
            return File(file, "image/jpg", "notfound.jpg");
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
