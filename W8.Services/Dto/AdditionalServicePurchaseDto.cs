using W8.Services.Dto.Utils;

namespace W8.Services.Dto
{
    /// <summary>
    /// Un acquisto di un servizio aggiuntivo in una prenotazione.
    /// </summary>
    public class AdditionalServicePurchaseDto : BaseDto
    {
        /// <summary>
        /// Il servizio acquistato.
        /// </summary>
        public required AdditionalServiceDto AdditionalService { get; set; }
        /// <summary>
        /// Il periodo di tempo.
        /// </summary>
        public required Timelapse Timelapse { get; set; }
        /// <summary>
        /// La quantità.
        /// </summary>
        public int Quantity { get; set; }
    }
}
