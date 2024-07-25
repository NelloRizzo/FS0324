namespace W8.D4.WebApi.DataLayer.Entities
{
    /// <summary>
    /// Entità persistente sulla tabella Articles.
    /// </summary>
    public class ArticleEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
    }
}
