namespace W2.D4.BlogWebApp.Entities
{
    /// <summary>
    /// Un articolo del blog.
    /// </summary>
    public class Article : BaseEntity
    {
        /// <summary>
        /// Titolo dell'articolo.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Contenuto dell'articolo.
        /// </summary>
        public string Content { get; set; }
    }
}
