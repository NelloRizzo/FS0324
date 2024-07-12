using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Areas.Admin.Controllers
{
    /// <summary>
    /// Classe di base per i controllers di applicazione.
    /// </summary>
    public class MvcBaseController : Controller
    {
        /// <summary>
        /// Gestore dei log applicativi.
        /// </summary>
        protected readonly ILogger<MvcBaseController> _logger;

        public MvcBaseController(ILogger<MvcBaseController> logger) {
            _logger = logger;
        }
    }
}
