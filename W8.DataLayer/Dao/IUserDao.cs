using W8.DataLayer.Entities;

namespace W8.DataLayer.Dao
{
    /// <summary>
    /// DAO per gli utenti.
    /// </summary>
    public interface IUserDao : IDao<UserEntity>
    {
        /// <summary>
        /// Recupera un utente tramite username.
        /// </summary>
        /// <param name="username">Username da cercare.</param>
        Task<UserEntity> ReadByUsernameAsync(string username);
        /// <summary>
        /// Recupera un utente tramite username e password.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password.</param>
        Task<UserEntity> ReadByUsernameAndPasswordAsync(string username, string password);
    }
}
