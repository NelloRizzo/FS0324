namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Tabella dei ruoli.
    /// </summary>
    public class RoleEntity : BaseEntity
    {
        /// <summary>
        /// Nome del ruolo.
        /// </summary>
        public required string RoleName { get; set; }
    }
}
