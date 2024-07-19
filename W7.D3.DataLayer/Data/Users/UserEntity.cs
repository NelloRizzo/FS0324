namespace W7.D3.DataLayer.Data.Users
{
    /// <summary>
    /// Entità che rappresenta un utente sul database.
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Chiave primaria.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Username.
        /// </summary>
        public required string Username { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Data di nascita.
        /// </summary>
        public DateOnly Birthday { get; set; }
    }
}
