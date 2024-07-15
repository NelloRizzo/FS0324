using Microsoft.AspNetCore.Mvc;
using W7.D1.WebApp.Services;

namespace W7.D1.WebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMyService service;
        private readonly ILogger<ServiceController> logger;
        public ServiceController(IMyService myService, ILogger<ServiceController> logger) {
            service = myService;
            this.logger = logger;
        }
        public IActionResult Index() {
            logger.LogInformation("Sto eseguendo il metodo Index()");
            //var service = new W7.D1.WebApp.Services.V2.MyService();
            //var service = new W7.D1.WebApp.Services.V1.MyService();
            ViewBag.Data = service.UseService();
            logger.LogWarning($"Il valore di Data è {ViewBag.Data}");
            Thread.Sleep(2000);
            return View();
        }
    }
}
