using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : MvcBaseController
    {
        public AdminHomeController(ILogger<AdminHomeController> logger) : base(logger) { }

        public IActionResult Index() {
            return View();
        }

    }
}
