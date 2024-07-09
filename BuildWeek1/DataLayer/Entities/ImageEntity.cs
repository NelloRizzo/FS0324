namespace BuildWeek1.DataLayer.Entities
{
    /// <summary>
    /// Un'immagine.
    /// </summary>
    public class ImageEntity : BaseEntity
    {
        /// <summary>
        /// Chiave esterna verso i prodotti.
        /// </summary>
        /// <remarks>Se è <b>null</b> significa che l'immagine non è collegata
        /// ad alcun prodotto ma è gestita per altri scopi.</remarks>
        public int? ProductId { get; set; }
        /// <summary>
        /// Titolo.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Contenuto in bytes.
        /// </summary>
        public required byte[] Content { get; set; }
        /// <summary>
        /// Tipo MIME dell'immagine.
        /// </summary>
        public required string MimeType { get; set; }
        /// <summary>
        /// Eventuale larghezza.
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Eventuale altezza.
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// Eventuale risoluzione (DPI).
        /// </summary>
        public int? Dpi { get; set; }
    }
}
