using BuildWeek1.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Controllers
{
    public class AdminController : MvcBaseController
    {
        public AdminController(DbContext context, ILogger<AdminController> logger) : base(context, logger) { }

        public IActionResult Index() {
            return View();
        }

    }
}
