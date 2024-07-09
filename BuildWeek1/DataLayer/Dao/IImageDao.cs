using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione del DAO per la gestione delle immagini.
    /// </summary>
    public interface IImageDao : IDao<ImageEntity>
    {
        /// <summary>
        /// Ottiene tutte le immagini.
        /// </summary>
        IEnumerable<ImageEntity> ReadAll();
    }
}
