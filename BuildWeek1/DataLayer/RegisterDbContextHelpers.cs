using BuildWeek1.DataLayer.Dao;
using BuildWeek1.DataLayer.Dao.SqlServer;

namespace BuildWeek1.DataLayer
{
    public static class RegisterDbContextHelpers
    {
        /// <summary>
        /// Registra il contesto dati nel sistema di Inversion of Control per la D.I.
        /// </summary>
        public static IServiceCollection AddDbContext(this IServiceCollection services) =>
            services
                // poiché arrivano chiamate da parte dei client per il recupero delle immagini,
                // i DAO sono legati alla singola richiesta, in maniera da poter effettuare contemporaneamente
                // chiamate diverse allo stesso database (in regime di concorrenza, la connessione sarebbe inutilizzabile
                // con l'inizializzazione Singleton, perché unica e acceduta contemporaneamente da più parti)
                .AddScoped<ICartItemDao, SqlCartItemDao>()
                .AddScoped<IImageDao, SqlImageDao>()
                .AddScoped<IProductDao, SqlProductDao>()

                // la classe DbContext consente di gestire tramite un unico oggetto tutti i DAO
                .AddScoped<DbContext>()
            ;
    }
}
