namespace W2.D4.BlogWebApp.Models
{
    public class ArticleInputModel
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public IFormFile Cover { get; set; }
    }
}
