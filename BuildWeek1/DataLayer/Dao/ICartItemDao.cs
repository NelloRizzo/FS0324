using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione del DAO per la gestione delle righe del carrello.
    /// </summary>
    public interface ICartItemDao : IDao<CartItemEntity>
    {
        /// <summary>
        /// Elenca i prodotti in carrello.
        /// </summary>
        /// <param name="cartId">Chiave del carrello.</param>
        IEnumerable<CartItemEntity> ReadAllByCartId(int cartId);
    }
}
