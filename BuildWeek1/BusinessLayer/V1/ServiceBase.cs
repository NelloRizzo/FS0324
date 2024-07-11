using BuildWeek1.DataLayer;

namespace BuildWeek1.BusinessLayer.V1
{
    /// <summary>
    /// Classe di base per tutte le classi di servizio.
    /// </summary>
    /// <remarks>Si è approfittato della classe per implementare eventualmente
    /// i metodi previsti dall'interfaccia di base.</remarks>
    public class ServiceBase : IServiceBase
    {
        /// <summary>
        /// Contesto dati.
        /// </summary>
        /// <remarks>Essendo <strong>protected</strong> è accessibile da tutte le sottoclassi.</remarks>
        protected readonly DbContext _dbContext;
        /// <summary>
        /// Gestione dei log.
        /// </summary>
        protected readonly ILogger<IServiceBase> _logger;

        public ServiceBase(DbContext dbContext, ILogger<IServiceBase> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
