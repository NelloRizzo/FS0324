using System.Web.Mvc;
using WebMvcSample.Controllers.Models;

namespace WebMvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate(FormCollection form)
        {
            if (decimal.TryParse(form["first"], out decimal first) && decimal.TryParse(form["second"], out decimal second))
            {
                decimal f = first;
                switch (form["operation"])
                {
                    case "+": first += second; break;
                    case "-": first -= second; break;
                    case "*": first *= second; break;
                    case "/": first /= second; break;
                }
                CalculateModel model = new CalculateModel { First = f, Second = second, Operation = form["operation"][0], Result = first };
                return View(model);
            }

            return View("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}