using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione del DAO per la gestione dei prodotti.
    /// </summary>
    public interface IProductDao : IDao<ProductEntity>
    {
        /// <summary>
        /// Ottiene l'elenco di tutti i prodotti.
        /// </summary>
        IEnumerable<ProductEntity> ReadAll();
    }
}
