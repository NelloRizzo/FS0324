using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W7.D3.DataLayer;

namespace W7.D3.BusinessLayer
{
    /// <summary>
    /// Classe di base per tutti i servizi.
    /// </summary>
    /// <remarks>Serve per implementare tutte le funzionalità ripetitive 
    /// nei vari servizi, centralizzandole in un unico punto.</remarks>
    public class BaseService
    {
        /// <summary>
        /// Contesto dati.
        /// </summary>
        protected readonly DbContext dbContext;
        /// <summary>
        /// Gestore dei log.
        /// </summary>
        protected readonly ILogger<BaseService> logger;

        public BaseService(DbContext dbContext, ILogger<BaseService> logger) {
            this.dbContext = dbContext;
            this.logger = logger;
        }
    }
}
