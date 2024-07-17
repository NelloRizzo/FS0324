using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer
{
    /// <summary>
    /// DAO per i ruoli.
    /// </summary>
    public interface IRoleDao
    {
        /// <summary>
        /// Crea un ruolo.
        /// </summary>
        /// <param name="roleName">Nome del ruolo.</param>
        /// <returns>Il ruolo dopo la persistenza.</returns>
        RoleEntity Create(string roleName);
        /// <summary>
        /// Elimina un ruolo.
        /// </summary>
        /// <param name="roleName">Nome del ruolo.</param>
        /// <returns>Il ruolo eliminato.</returns>
        RoleEntity Delete(int roleName);
        /// <summary>
        /// Recupera i dati di un ruolo.
        /// </summary>
        /// <param name="roleName">Nome del ruolo.</param>
        RoleEntity Read(string roleName);
        /// <summary>
        /// Recupera tutti i ruoli.
        /// </summary>
        List<string> ReadAll();
    }
}
