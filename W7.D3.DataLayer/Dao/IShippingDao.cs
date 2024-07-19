using W7.D3.DataLayer.Data.Shippinggs;

namespace W7.D3.DataLayer.Dao
{
    /// <summary>
    /// DAO per le consegne.
    /// </summary>
    public interface IShippingDao
    {
        /// <summary>
        /// Aggiunge una consegna.
        /// </summary>
        /// <param name="shipping">Dati della consegna.</param>
        /// <returns>La consegna dopo l'inserimento nel database.</returns>
        ShippingEntity Create(ShippingEntity shipping);
        /// <summary>
        /// Recupera i dati di una consegna.
        /// </summary>
        /// <param name="id">Chiave della consegna.</param>
        ShippingEntity Read(int id);
        /// <summary>
        /// Recupera l'elenco di tutte le consegne.
        /// </summary>
        IEnumerable<ShippingEntity> ReadAll();
    }
}
