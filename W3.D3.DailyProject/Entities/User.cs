namespace W3.D3.DailyProject.Entities
{
    /// <summary>
    /// Un utente.
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        /// Il nome.
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// Il cognome.
        /// </summary>
        public required string LastName { get; set; }
    }
}
