using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using W3.D4.Ado.Models;

namespace W3.D4.Ado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config) {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index() {
            // 1. Creazione di una connessione con il database
            // 1.1. Recupero la stringa di connessione
            var connStr = _config.GetConnectionString("AppConn");
            // 1.2. Creazione dell'oggetto che gestisce la connessione
            var conn = new SqlConnection(connStr);
            // per MySQL
            // var mysql = new MySqlConnector.MySqlConnection(connStr);
            // 2. Preparazione del comando di SELECT
            // 3. Esecuzione del comando di SELECT con ottenimento del "cursore"
            // 4. Attraversamento del cursore
            // 5. Creazione di un Customer per ogni riga attraversata
            // 6. Chiusura della connessione
            return View();
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
