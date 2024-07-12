using BuildWeek1.BusinessLayer.Dto;

namespace BuildWeek1.BusinessLayer
{
    /// <summary>
    /// Gestione del carrello.
    /// </summary>
    public interface IShoppingCartService : IServiceBase
    {
        /// <summary>
        /// Crea un nuovo carrello per un utente.
        /// </summary>
        /// <param name="customerId">Identificativo dell'utente.</param>
        /// <param name="shipFare">Spese di spedizione.</param>
        /// <returns>Il nuovo carrello.</returns>
        ShoppingCartDto Create(string customerId, decimal shipFare);
        /// <summary>
        /// Aggiunge un prodotto al carrello.
        /// </summary>
        /// <param name="cartId">Chiave del carrello.</param>
        /// <param name="productId">Chiave del prodotto.</param>
        /// <param name="quantity">Quantità da aggiungere.</param>
        /// <returns>Il carrello dopo l'aggiunta.</returns>
        ShoppingCartDto AddProduct(int cartId, int productId, int quantity);
        /// <summary>
        /// Rimuove un prodotto dal carrello.
        /// </summary>
        /// <param name="cartId">Chiave del carrello.</param>
        /// <param name="productId">Chiave del prodotto.</param>
        /// <returns>Il carrello dopo la rimozione.</returns>
        ShoppingCartDto RemoveProduct(int cartId, int productId);
        /// <summary>
        /// Chiude un carrello.
        /// </summary>
        /// <param name="cartId">Chiave del carrello.</param>
        /// <returns>Il carrello dopo la chiusura.</returns>
        ShoppingCartDto Close(int cartId);
        /// <summary>
        /// Elimina un carrello.
        /// </summary>
        /// <param name="cartId">Chiave del carrello.</param>
        /// <returns>Il carrello dopo la chiusura.</returns>
        ShoppingCartDto Delete(int cartId);
        /// <summary>
        /// Recupera un carrello.
        /// </summary>
        /// <param name="cartId">Chiave del carrello.</param>
        ShoppingCartDto Get(int cartId);
        /// <summary>
        /// Elenca i carrelli di un utente.
        /// </summary>
        /// <param name="customerId">Identificativo del cliente.</param>
        /// <param name="showClosed">Indica se elencare anche i carrelli chiusi.</param>
        /// <returns>I carrelli associati al cliente.</returns>
        IEnumerable<ShoppingCartDto> GetAllByCustomerId(string customerId, bool showClosed);
        /// <summary>
        /// Elenca tutti i carrelli.
        /// </summary>
        /// <param name="showClosed">Indica se elencare anche i carrelli chiusi.</param>
        /// <returns>Tutti i carrelli gestiti.</returns>
        IEnumerable<ShoppingCartDto> GetAll(bool showClosed);
    }
}
