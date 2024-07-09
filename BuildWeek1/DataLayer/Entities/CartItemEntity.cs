namespace BuildWeek1.DataLayer.Entities
{
    /// <summary>
    /// Una riga del carrello.
    /// </summary>
    public class CartItemEntity : BaseEntity
    {
        /// <summary>
        /// Chiave esterna verso i prodotti.
        /// </summary>
        public required int ProductId { get; set; }
        /// <summary>
        /// Chiave esterna verso i carrelli.
        /// </summary>
        public required int CartId { get; set; }
        /// <summary>
        /// Quantità acquistata.
        /// </summary>
        public required int Quantity { get; set; }
    }
}
