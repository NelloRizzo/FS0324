using W8.D4.WebApi.DataLayer.Entities;

namespace W8.D4.WebApi.DataLayer.Dao
{
    /// <summary>
    /// DAO per autori.
    /// </summary>
    public interface IAuthorDao : IDao<AuthorEntity>
    {
        /// <summary>
        /// Recupera un utente a partire dalle sue credenziali.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        Task<AuthorEntity?> GetByUsernameAndPasswordAsync(string username, string password);
    }
}
