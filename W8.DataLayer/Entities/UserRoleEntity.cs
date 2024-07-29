namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Tabella associativa Utenti/Ruoli
    /// </summary>
    public class UserRoleEntity : BaseEntity
    {
        /// <summary>
        /// Foreign key verso gli utenti.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Foreign key verso i ruoli.
        /// </summary>
        public int RoleId { get; set; }
    }
}
