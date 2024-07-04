namespace W3.D4.AdoWebApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content {  get; set; }
        public DateTime PublicationDate { get; set; }
        public int ArticleId { get; set; }
    }
}
