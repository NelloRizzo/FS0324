using W3.D3.DailyProject.Entities;

namespace W3.D3.DailyProject.Services
{
    /// <summary>
    /// Servizi per la gestione delle vendite.
    /// </summary>
    public interface IPurchaseService
    {
        /// <summary>
        /// Ottiene l'elenco di tutti i biglietti acquistati
        /// </summary>
        IEnumerable<Purchase> GetPurchases();
        /// <summary>
        /// Aggiunge un nuovo acquisto.
        /// </summary>
        /// <param name="purchase">I dati relativi all'acquisto effettuato.</param>
        void AddPurchase(Purchase purchase);
        /// <summary>
        /// Ottiene le statistiche di riempimento delle sale.
        /// </summary>
        IEnumerable<Statistics> GetStatistics();
    }
}
