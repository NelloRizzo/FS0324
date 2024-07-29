namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Tabella di collegamento tra Prenotazioni e Servizi Aggiuntivi.
    /// </summary>
    public class AdditionalServicePurchaseEntity : BaseEntity
    {
        /// <summary>
        /// Servizio acquistato.
        /// </summary>
        public int AdditionalServiceId { get; set; }
        /// <summary>
        /// Prenotazione.
        /// </summary>
        public int ReservationId { get; set; }
        /// <summary>
        /// Data inizio.
        /// </summary>
        public DateOnly From { get; set; }
        /// <summary>
        /// Data fine.
        /// </summary>
        public DateOnly To { get; set; }
        /// <summary>
        /// Quantità acquistata.
        /// </summary>
        public int Quantity { get; set; }
    }
}
