using Microsoft.AspNetCore.Mvc;

namespace W8.WebApp.Controllers
{
    /// <summary>
    /// Elementi in comune a tutti i controllers.
    /// </summary>
    public abstract class BaseController(ILogger<BaseController> logger) : Controller
    {
        /// <summary>
        /// Gestore dei log.
        /// </summary>
        protected ILogger<BaseController> _logger = logger;
    }
}
