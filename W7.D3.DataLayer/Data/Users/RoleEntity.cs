namespace W7.D3.DataLayer.Data.Users
{
    /// <summary>
    /// Un ruolo.
    /// </summary>
    public class RoleEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome del ruolo.
        /// </summary>
        public required string Name { get; set; }
    }
}
