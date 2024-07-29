using Microsoft.Extensions.Logging;
using W8.DataLayer;

namespace W8.Services.V1
{
    /// <summary>
    /// Elementi comuni a tutti i servizi.
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// Contesto dati.
        /// </summary>
        protected readonly DbContext _ctx;
        /// <summary>
        /// Gestore dei log.
        /// </summary>
        protected readonly ILogger<BaseService> _logger;
        public BaseService(DbContext dbContext, ILogger<BaseService> logger) {
            _ctx = dbContext;
            _logger = logger;
        }
    }
}
