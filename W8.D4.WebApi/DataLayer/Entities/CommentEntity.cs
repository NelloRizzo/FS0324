namespace W8.D4.WebApi.DataLayer.Entities
{
    /// <summary>
    /// Commento persistente sulla tabella Comments.
    /// </summary>
    public class CommentEntity
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public int AuthorId { get; set; }
        public int ArticleId { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
