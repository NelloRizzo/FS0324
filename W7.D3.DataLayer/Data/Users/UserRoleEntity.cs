namespace W7.D3.DataLayer.Data.Users
{
    /// <summary>
    /// Associazione utente-ruolo.
    /// </summary>
    public class UserRoleEntity
    {
        /// <summary>
        /// Chiave per l'utente.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Chiave per il ruolo.
        /// </summary>
        public int RoleId { get; set; }
    }
}
