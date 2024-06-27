using W2.D4.BlogWebApp.Entities;

namespace W2.D4.BlogWebApp.Services
{
    public interface ICommentService : ICrudService<Comment>
    {
        /// <summary>
        /// Ottenimento di un elenco di articoli.
        /// </summary>
        /// <param name="articleId">Chiave identificativa dell'articolo al quale i commenti si riferiscono.</param>
        /// <returns>L'elenco degli articoli.</returns>
        IEnumerable<Comment> GetAll(int articleId);
    }
}
