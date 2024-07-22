using W7.D3.BusinessLayer.Data;

namespace W7.D3.BusinessLayer
{
    /// <summary>
    /// Servizi per la gestione delle consegne.
    /// </summary>
    public interface IShippingService
    {
        /// <summary>
        /// Aggiunge una consegna.
        /// </summary>
        /// <param name="shipping">Dati della consegna.</param>
        /// <returns>La consegna aggiunta.</returns>
        ShippingDto Perform(ShippingDto shipping);
        /// <summary>
        /// Recupera una consegna.
        /// </summary>
        /// <param name="Id">Chiave della consegna.</param>
        ShippingDto Get(int Id);
        /// <summary>
        /// Aggiorna una consegna.
        /// </summary>
        /// <param name="shippingId">Chiave della consegna.</param>
        /// <param name="shippingUpdate">Dati per l'aggiornamento.</param>
        ShippingDto Update(int shippingId, ShippingUpdateDto shippingUpdate);
        /// <summary>
        /// Recupera tutte le consegne.
        /// </summary>
        IEnumerable<ShippingDto> GetAll();
    }
}
