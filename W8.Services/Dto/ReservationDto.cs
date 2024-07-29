using W8.Services.Dto.Utils;

namespace W8.Services.Dto
{
    /// <summary>
    /// Tipo di pernottamento.
    /// </summary>
    public enum OvernightType
    {
        /// <summary>
        /// Mezza pensione.
        /// </summary>
        HalfBoard,
        /// <summary>
        /// Pensione completa.
        /// </summary>
        FullBoard,
        /// <summary>
        /// Prima colazione.
        /// </summary>
        Breakfast
    }
    /// <summary>
    /// Una prenotazione.
    /// </summary>
    public class ReservationDto : BaseDto
    {
        /// <summary>
        /// Camera.
        /// </summary>
        public required RoomDto Room { get; set; }
        /// <summary>
        /// Cliente.
        /// </summary>
        public required CustomerDto Customer { get; set; }
        /// <summary>
        /// Data della prenotazione.
        /// </summary>
        public DateOnly Date { get; set; }
        /// <summary>
        /// Progrgessivo annuo.
        /// </summary>
        public required string YearlyNumber { get; set; }
        /// <summary>
        /// Durata del soggiorno.
        /// </summary>
        public required Timelapse Timelapse { get; set; }
        /// <summary>
        /// Cauzione.
        /// </summary>
        public required decimal Deposit { get; set; }
        /// <summary>
        /// Tariffa.
        /// </summary>
        public required decimal Fare { get; set; }
        /// <summary>
        /// Tipo di pernottamento.
        /// </summary>
        public required OvernightType OvernightType { get; set; }
        /// <summary>
        /// Servizi aggiuntivi acquistati.
        /// </summary>
        public List<AdditionalServicePurchaseDto> AdditionalServices { get; } = [];
    }
}
