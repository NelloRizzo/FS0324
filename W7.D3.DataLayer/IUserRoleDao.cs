using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer
{
    /// <summary>
    /// DAO per le associazioni utente-ruolo.
    /// </summary>
    public interface IUserRoleDao
    {
        /// <summary>
        /// Crea un'associazione.
        /// </summary>
        /// <param name="roleId">Chiave del ruolo.</param>
        /// <param name="userId">Chiave dell'utente.</param>
        void Create(int userId, int roleId);
        /// <summary>
        /// Elimina un'associazione utente-ruolo.
        /// </summary>
        /// <param name="roleId">Chiave del ruolo.</param>
        /// <param name="userId">Chiave dell'utente.</param>
        void Delete(int userId, int roleId);
        /// <summary>
        /// Recupera tutti i ruoli di un utente.
        /// </summary>
        /// <param name="username">Il nome dell'utente.</param>
        List<string> GetAllByUserId(string username);
    }
}
