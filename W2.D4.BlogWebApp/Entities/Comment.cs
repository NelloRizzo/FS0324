namespace W2.D4.BlogWebApp.Entities
{
    /// <summary>
    /// Commento ad un articolo.
    /// </summary>
    public class Comment : BaseEntity
    {
        /// <summary>
        /// Contenuto del commento.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Articolo al quale il commento si riferisce.
        /// </summary>
        public Article Article { get; set; }
    }
}