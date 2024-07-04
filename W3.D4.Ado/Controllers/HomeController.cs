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
            // modello dati da passare alla view
            var list = new List<Customer>();
            // 1. Creazione di una connessione con il database
            // 1.1. Recupero la stringa di connessione
            var connStr = _config.GetConnectionString("AppConn");
            // 1.2. Creazione dell'oggetto che gestisce la connessione
            var conn = new SqlConnection(connStr);
            // per MySQL
            // var mysql = new MySqlConnector.MySqlConnection(connStr);
            // 1.3. Apertura della connessione
            conn.Open();
            // 2. Preparazione del comando di SELECT
            var cmd = new SqlCommand("SELECT * FROM Customers", conn);
            // 3. Esecuzione del comando di SELECT con ottenimento del "cursore"
            var reader = cmd.ExecuteReader();
            // 4. Attraversamento del cursore
            while (reader.Read()) {
                // 5. Creazione di un Customer per ogni riga attraversata
                var customer = new Customer {
                    Address = reader["Address"].ToString(),
                    City = reader["City"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),
                    ContactName = reader["ContactName"].ToString(),
                    ContactTitle = reader["ContactTitle"].ToString(),
                    Country = reader["Country"].ToString(),
                    CustomerID = reader["CustomerID"].ToString(),
                    Fax = reader["Fax"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    PostalCode = reader["PostalCode"].ToString(),
                    Region = reader["Region"].ToString()
                };
                list.Add(customer);
            }
            // 6. Chiusura della connessione
            conn.Close();
            return View(list);
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
