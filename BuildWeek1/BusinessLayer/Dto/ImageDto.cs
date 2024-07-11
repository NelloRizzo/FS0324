namespace BuildWeek1.BusinessLayer.Dto
{
    /// <summary>
    /// Immagine.
    /// </summary>
    public class ImageDto : DtoBase
    {
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
        /// <summary>
        /// Il prodotto collegato.
        /// </summary>
        public ProductDto? Product { get; set; }

        public override bool IsValid => base.IsValid &&
            // se la larghezza è impostata deve essere > 0
            (!Width.HasValue || Width > 0) &&
            // se l'altezza è impostata deve essere > 0
            (!Height.HasValue || Height > 0) &&
            // se i dpi sono impostati devono essere > 0
            (!Dpi.HasValue || Dpi > 0);
    }
}
