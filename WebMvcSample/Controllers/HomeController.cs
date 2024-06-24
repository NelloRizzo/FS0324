using System.Web.Mvc;
using WebMvcSample.Controllers.Models;

namespace WebMvcSample.Controllers
{
    // Il CONTROLLER orchestra la comunicazione
    public class HomeController : Controller
    {
        // Azione Index, mostra solo la vista Views/Home/Index.cshtml
        public ActionResult Index() {
            return View();
        }
        // Azione Calculate, risponde al submit del form nell'index
        // riceve in input ciò che l'utente ha inserito nel form
        // in un oggetto FormCollection che consente di accedere ai campi
        // attraverso una notazione con []
        public ActionResult Calculate(FormCollection form) {
            // form['first'] accede al campo del form <input name='first'>
            if (decimal.TryParse(form["first"], out decimal first) && decimal.TryParse(form["second"], out decimal second)) {
                decimal f = first;
                switch (form["operation"]) {
                    case "+": first += second; break;
                    case "-": first -= second; break;
                    case "*": first *= second; break;
                    case "/": first /= second; break;
                }
                // prepara il modello da presentare nella vista
                CalculateModel model = new CalculateModel { First = f, Second = second, Operation = form["operation"][0], Result = first };
                // passa il controllo alla vista Views/Home/Calculate.cshtml
                // e trasferisce il modello dati
                return View(model);
            }

            return View("Index");
        }
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}