namespace W2.D4.BlogWebApp.Entities
{
    /// <summary>
    /// Entità di base per gli oggetti del blog.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Chiave identificativa.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Data e ora di pubblicazione.
        /// </summary>
        public DateTime PublishedAt { get; set; }
    }
}
