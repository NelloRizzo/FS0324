namespace W3.D3.DailyProject.Entities
{
    /// <summary>
    /// Tipologia di biglietto.
    /// </summary>
    public enum TicketType
    {
        /// <summary>
        /// Biglietto normale.
        /// </summary>
        Normal,
        /// <summary>
        /// Biglietto ridotto.
        /// </summary>
        Reduced
    }
    /// <summary>
    /// Un biglietto.
    /// </summary>
    public class Ticket : EntityBase
    {
        /// <summary>
        /// Il tipo di biglietto.
        /// </summary>
        public TicketType Type { get; set; }
    }
}
