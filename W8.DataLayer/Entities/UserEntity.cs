namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Tabella degli utenti.
    /// </summary>
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// Username.
        /// </summary>
        public required string UserName { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public required string Email { get; set; }
    }
}
