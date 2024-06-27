using W2.D4.BlogWebApp.Entities;

namespace W2.D4.BlogWebApp.Services
{
    /// <summary>
    /// Operazioni sugli articoli.
    /// </summary>
    public interface IArticleService : ICrudService<Article>
    {
        /// <summary>
        /// Ottenimento di un elenco di articoli.
        /// </summary>
        /// <returns>L'elenco degli articoli.</returns>
        IEnumerable<Article> GetAll();
    }
}
