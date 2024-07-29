using W8.Services.Dto;

namespace W8.Services.Interfaces
{
    /// <summary>
    /// Gestione utenti.
    /// </summary>
    public interface IUserService : ICrudService<UserDto>
    {
        /// <summary>
        /// Aggiunge un utente ad un ruolo.
        /// </summary>
        /// <param name="username">L'utente.</param>
        /// <param name="roleName">Il ruolo.</param>
        /// <exception cref="Exceptions.NotFoundException">Se l'utente non esiste.</exception>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        /// <remarks>Attenzione: il ruolo viene aggiunto ai ruoli applicativi se non esiste.</remarks>
        Task AddUserToRoleAsync(string username, string roleName);
        /// <summary>
        /// Rimuove un utente da un ruolo.
        /// </summary>
        /// <param name="username">L'utente.</param>
        /// <param name="roleName">Il ruolo.</param>
        /// <exception cref="Exceptions.NotFoundException">Se non esiste l'utente o il ruolo.</exception>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task RemoveUserFromRoleAsync(string username, string roleName);
        /// <summary>
        /// Ottiene tutti i ruoli attualmente presenti nell'applicazione.
        /// </summary>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<IEnumerable<string>> GetAllRolesAsync();
        /// <summary>
        /// Ottiene un utente a partire dalle credenziali di login.
        /// </summary>
        /// <param name="username">Username utilizzato per il login.</param>
        /// <param name="password">Password.</param>
        /// <returns>L'utente corrispondente alle credenziali o il valore <strong>null</strong> se le credenziali sono errate.</returns>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<UserDto?> LoginAsync(string username, string password);
        /// <summary>
        /// Ottiene i dati di un utente a partire dallo username.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>L'utente corrispondente allo username o il valore <strong>null</strong> se non esiste.</returns>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<UserDto?> GetUserByUsername(string username);
    }
}
