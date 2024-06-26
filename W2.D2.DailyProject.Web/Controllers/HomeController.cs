using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W2.D2.DailyProject.Business.Services;
using W2.D2.DailyProject.Web.Models;

namespace W2.D2.DailyProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurriculumService _curriculumService;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, ICurriculumService curriculumService, IWebHostEnvironment env) {
            _logger = logger;
            _curriculumService = curriculumService;
            _env = env;
        }

        public IActionResult Index() {
            return View(_curriculumService.GetCurriculum());
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
