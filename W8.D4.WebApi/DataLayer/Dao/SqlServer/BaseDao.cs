namespace W8.D4.WebApi.DataLayer.Dao.SqlServer
{
    /// <summary>
    /// Serve a gestire le funzionalità comuni a tutti i DAO.
    /// </summary>
    public abstract class BaseDao
    {
        /// <summary>
        /// Stringa di connessione.
        /// </summary>
        // Protected perché deve essere messa a disposizione delle sottoclassi.
        protected readonly string connectionString;
        /// <summary>
        /// Gestore dei log.
        /// </summary>
        protected readonly ILogger<BaseDao> logger;

        public BaseDao(IConfiguration config, ILogger<BaseDao> logger) {
            connectionString = config.GetConnectionString("SqlServer")!;
            this.logger = logger;
        }
    }
}
