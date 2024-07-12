using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione del DAO per la gestione dei carrelli.
    /// </summary>
    public interface IShoppingCartDao : IDao<ShoppingCartEntity>
    {
        /// <summary>
        /// Elenca tutti i carrelli di un cliente.
        /// </summary>
        /// <param name="customerId">Itentificativo del cliente.</param>
        /// <param name="retrieveClosed">Indica se recuperare anche i carrelli chiusi.</param>
        IEnumerable<ShoppingCartEntity> ReadAllByCustomerId(string customerId, bool retrieveClosed);

        /// <summary>
        /// Elenca tutti i carrelli.
        /// </summary>
        /// <param name="retrieveClosed">Indica se recuperare anche i carrelli chiusi.</param>
        IEnumerable<ShoppingCartEntity> ReadAll(bool retrieveClosed);

        /// <summary>
        /// Recupera un prodotto in carrello.
        /// </summary>
        /// <param name="cartId">Chiave del carrello.</param>
        /// <param name="productId">Chiave del prodotto.</param>
        /// <returns>Il prodotto nel carrello.</returns>
        ShoppingCartEntity? Read(int cartId, int productId);
    }
}
