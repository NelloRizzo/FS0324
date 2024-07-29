using W8.D4.WebApi.DataLayer.Dao;

namespace W8.D4.WebApi.DataLayer
{
    /// <summary>
    /// Raccolta di tutti i DAO disponibili per l'applicazione.
    /// </summary>
    public class DataContext
    {
        public IArticleDao Articles { get; }
        public ICommentDao Comments { get; }
        public IAuthorDao Authors { get; }

        public DataContext(IArticleDao articles, ICommentDao comments, IAuthorDao authors) {
            Articles = articles;
            Comments = comments;
            Authors = authors;
        }
    }
}
