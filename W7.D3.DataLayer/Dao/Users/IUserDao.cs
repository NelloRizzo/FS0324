using W7.D3.DataLayer.Data.Users;

namespace W7.D3.DataLayer.Dao.Users
{
    /// <summary>
    /// DAO per la gestione degli utenti.
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// Creazione di un utente.
        /// </summary>
        /// <param name="user">Dati dell'utente.</param>
        /// <returns>L'utente dopo la persistenza.</returns>
        UserEntity Create(UserEntity user);
        /// <summary>
        /// Recupera un utente.
        /// </summary>
        /// <param name="userId">Chiave identificativa dell'utente.</param>
        UserEntity Read(int userId);
        /// <summary>
        /// Modifica i dati di un utente.
        /// </summary>
        /// <param name="userId">Chiave identificativa dell'utente.</param>
        /// <param name="user">Dati con i quali aggiornare l'utente.</param>
        /// <returns>L'utente dopo la persistenza.</returns>
        UserEntity Update(int userId, UserEntity user);
        /// <summary>
        /// Elimina un utente.
        /// </summary>
        /// <param name="userId">Chiave identificativa dell'utente.</param>
        /// <returns>L'utente eliminato.</returns>
        UserEntity Delete(int userId);
        /// <summary>
        /// Recupera tutti i dati dell'utente tramite lo username.
        /// </summary>
        /// <param name="username">Username dell'utente.</param>
        /// <returns>I dati dell'utente.</returns>
        UserEntity ReadByUsername(string username);
        /// <summary>
        /// Ottiene l'elenco degli utenti nel database.
        /// </summary>
        List<UserEntity> ReadAll();
        /// <summary>
        /// Recupera un utente per il login.
        /// </summary>
        /// <param name="username">Username.</param>
        UserEntity? Login(string username);
    }
}
