namespace BuildWeek1.BusinessLayer.Dto
{
    /// <summary>
    /// Prodotto.
    /// </summary>
    public class ProductDto : DtoBase
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
        public ImageDto? Image { get; set; }
        /// <summary>
        /// Prezzo.
        /// </summary>
        public required decimal Price { get; set; }

        public override bool IsValid =>
            base.IsValid &&
            // il titolo e la descrizione non possono essere composti da soli spazi
            !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Description) &&
            // l'immagine di copertina non è null
            Image != null &&
            // il prezzo deve essere maggiore di 0
            Price > 0;
    }
}
