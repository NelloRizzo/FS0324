using Microsoft.AspNetCore.Mvc;

namespace W8.WebApp.Controllers.Api
{
    /// <summary>
    /// Elementi comuni a tutti i controllers WebAPI.
    /// </summary>
    public class ApiBaseController : ControllerBase
    {
        /// <summary>
        /// Gestore dei log.
        /// </summary>
        protected ILogger<BaseController> _logger;
        public ApiBaseController(ILogger<BaseController> logger) {
            _logger = logger;
        }
    }
}
