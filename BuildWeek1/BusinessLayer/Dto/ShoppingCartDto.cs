namespace BuildWeek1.BusinessLayer.Dto
{
    /// <summary>
    /// Una carrello.
    /// </summary>
    public class ShoppingCartDto : DtoBase
    {
        /// <summary>
        /// Data di creazione.
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Riferimento al cliente.
        /// </summary>
        public required string CustomerId { get; set; }
        /// <summary>
        /// Spese di spedizione.
        /// </summary>
        public decimal ShipFare { get; set; }
        /// <summary>
        /// Indica se il carrello è chiuso.
        /// </summary>
        public bool Closed { get; set; }
        /// <summary>
        /// Prodotti nel carrello.
        /// </summary>
        public IEnumerable<CartItemDto> Items { get; set; } = [];
    }
}
