namespace BuildWeek1.DataLayer.Entities
{
    /// <summary>
    /// Un prodotto.
    /// </summary>
    public class ProductEntity : BaseEntity
    {
        /// <summary>
        /// Denominazione del prodotto.
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Chiave verso l'immagine di copertina.
        /// </summary>
        public required int CoverId { get; set; }
        /// <summary>
        /// Prezzo.
        /// </summary>
        public required decimal Price { get; set; }
    }
}
