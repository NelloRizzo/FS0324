using Microsoft.AspNetCore.Mvc;

namespace W7.D1.WebApp.Controllers
{
    [Route("values")]
    public class ValueController : Controller
    {
        [Route("list/{start?}/{count?}")]
        public IActionResult Index(int start = 0, int count = 100) {
            ViewBag.Start = start;
            ViewBag.Count = count;
            return View();
        }
        [Route("mul/{first}/{second?}")]
        public IActionResult Multiply(int first=1, int second=1) {
            ViewBag.First = first;
            ViewBag.Second = second;
            return View();
        }
    }
}
