namespace W8.Services.Dto
{
    /// <summary>
    /// Un servizio aggiuntivo.
    /// </summary>
    public class AdditionalServiceDto : BaseDto
    {
        /// <summary>
        /// Descrizione.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Prezzo.
        /// </summary>
        public required decimal Price { get; set; }
    }
}