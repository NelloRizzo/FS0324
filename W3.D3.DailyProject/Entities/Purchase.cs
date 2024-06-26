namespace W3.D3.DailyProject.Entities
{
    /// <summary>
    /// La registrazione dell'acquisto di un biglietto.
    /// </summary>
    public class Purchase : EntityBase
    {
        /// <summary>
        /// Il biglietto acquistato.
        /// </summary>
        public required Ticket Ticket { get; set; }
        /// <summary>
        /// L'utente che acquista il biglietto.
        /// </summary>
        public required User User { get; set; }
        /// <summary>
        /// La sala del cinema.
        /// </summary>
        public required Room Room { get; set; }
    }
}
