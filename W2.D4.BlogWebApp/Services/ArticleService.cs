using W2.D4.BlogWebApp.Entities;

namespace W2.D4.BlogWebApp.Services
{
    public class ArticleService : CrudService<Article>, IArticleService
    {
        public IEnumerable<Article> GetAll() => entities;
    }
}
