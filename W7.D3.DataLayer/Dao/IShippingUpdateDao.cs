using W7.D3.DataLayer.Data.Shippinggs;

namespace W7.D3.DataLayer.Dao
{
    /// <summary>
    /// DAO per la gestione degli aggiornamenti delle consegne.
    /// </summary>
    public interface IShippingUpdateDao
    {
        /// <summary>
        /// Aggiunge un aggiornamento.
        /// </summary>
        /// <param name="shippingUpdateEntity">Dati dell'aggiornamento.</param>
        /// <returns>L'aggiornamento dopo l'inserimento sul database.</returns>
        ShippingUpdateEntity Create(ShippingUpdateEntity shippingUpdateEntity);
        /// <summary>
        /// Recupera gli aggiornamenti di una consegna.
        /// </summary>
        /// <param name="shippingId">Chiave della consegna.</param>
        IEnumerable<ShippingUpdateEntity> GetAllByShippingId(int shippingId);
    }
}
