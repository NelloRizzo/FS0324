using W3.D4.AdoWebApp.Models;

namespace W3.D4.AdoWebApp.Services
{
    public interface IArticleService
    {
        void WriteArticle(Article article);
        IEnumerable<Article> GetArticles();
        Article GetArticle(int id);
        void UpdateArticle(int id, Article article);
        void DeleteArticle(int id);
    }
}
