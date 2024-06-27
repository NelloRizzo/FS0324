using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W3.D3.DailyProject.Entities;
using W3.D3.DailyProject.Models;
using W3.D3.DailyProject.Services;

namespace W3.D3.DailyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// Il riferimento al servizio di gestione delle vendite.
        /// </summary>
        private readonly IPurchaseService _purchaseService;
        /// <summary>
        /// Il riferimento al servizio di gestione delle sale.
        /// </summary>
        private readonly IRoomService _roomService;

        public HomeController(ILogger<HomeController> logger, IPurchaseService purchaseService, IRoomService roomService) {
            _logger = logger;
            // memorizza il riferimento al servizio di gestione delle vendite, creato tramite DI e passato al costruttore
            _purchaseService = purchaseService;
            // memorizza il riferimento al servizio di gestione delle sale, creato tramite DI e passato al costruttore
            _roomService = roomService;
        }

        public IActionResult Index() {
            return View(_purchaseService.GetStatistics());
        }

        /// <summary>
        /// Mostra la form per l'inserimento dei dati di vendita.
        /// </summary>
        /// <returns>
        /// La vista per l'inserimento dati.
        /// </returns>
        public IActionResult Purchase() {
            var fullRooms =
                // recupera tutte le statistiche
                _purchaseService.GetStatistics()
                // cerca solo quelle dove non c'è più posto in sala
                .Where(s => s.Attendance == s.Room.MaxAttendance)
                // e prende la sala
                .Select(s => s.Room);
            // recupera solo le sale che hanno posti liberi
            var rooms = _roomService.GetRooms().Where(r => !fullRooms.Contains(r)).OrderBy(r => r.Name);
            // passa i dati alla vista
            ViewBag.Rooms = rooms;
            return View(new PurchaseViewModel { Rooms = rooms });
        }

        /// <summary>
        /// Recupera i dati inseriti nella form di inserimento dei dati di vendita.
        /// </summary>
        /// <param name="model">Il modello dati gestito dalla form.</param>
        /// <returns>La vista di riepilogo (Index).</returns>
        [HttpPost]
        public IActionResult Purchase(PurchaseViewModel model) {
            var room = _roomService.GetRooms().Single(r => r.Id == model.RoomId);
            _purchaseService.AddPurchase(new Purchase {
                Room = room,
                Ticket = new Ticket { Type = model.Type },
                User = new User { FirstName = model.UserFirstName!, LastName = model.UserLastName! }
            });
            return RedirectToAction("Index"); // preferibilmente: nameof(Index);
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
