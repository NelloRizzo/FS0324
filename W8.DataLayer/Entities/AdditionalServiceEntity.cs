namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Tabella dei servizi aggiuntivi.
    /// </summary>
    public class AdditionalServiceEntity : BaseEntity
    {
        /// <summary>
        /// Descrizione del servizio.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Prezzo unitario.
        /// </summary>
        public decimal Price { get; set; }
    }
}
