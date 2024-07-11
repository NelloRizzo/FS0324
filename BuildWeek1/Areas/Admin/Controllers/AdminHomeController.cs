using BuildWeek1.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : MvcBaseController
    {
        public AdminHomeController(DbContext context, ILogger<AdminHomeController> logger) : base(context, logger) { }

        public IActionResult Index()
        {
            return View();
        }

    }
}
