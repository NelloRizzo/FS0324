using System.Data;
using W8.D4.WebApi.DataLayer.Entities;

namespace W8.D4.WebApi.DataLayer.Dao
{
    /// <summary>
    /// DAO per gli articoli.
    /// </summary>
    // la notazione seguente significa che, innanzitutto, questa interfaccia contiene tutti i metodi di IDao
    // sostituendo al parametro generico E (di IDao) il tipo ArticleEntity
    public interface IArticleDao : IDao<ArticleEntity> 
    {
        /// <summary>
        /// Recupera tutti gli articoli.
        /// </summary>
        Task<IEnumerable<ArticleEntity>> ReadAllAsync();
    }
}
