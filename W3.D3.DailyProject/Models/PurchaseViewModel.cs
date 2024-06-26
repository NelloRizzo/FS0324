using System.ComponentModel.DataAnnotations;
using W3.D3.DailyProject.Entities;

namespace W3.D3.DailyProject.Models
{
    /// <summary>
    /// Modello per la vista per la creazione di un nuovo acquisto.
    /// </summary>
    public class PurchaseViewModel
    {
        /// <summary>
        /// L'elenco delle sale.
        /// </summary>
        /// <remarks>Il modificatore <i>required</i> (introdotto dal C# v. 11) indica che il valore di questa
        /// proprietà <strong>deve necessariamente</strong> essere impostato quando si crea un'istanza della classe.</remarks>
        public required IEnumerable<Room> Rooms { get; set; }
        /// <summary>
        /// Il tipo di biglietto acquistato.
        /// </summary>
        [Display(Name = "Tipo di biglietto")]
        public TicketType Type { get; set; }
        /// <summary>
        /// La sala prenotata.
        /// </summary>
        [Display(Name = "Sala"), Required]
        public int RoomId { get; set; }
        /// <summary>
        /// Il nome dell'utente.
        /// </summary>
        [Display(Name = "Nome"), Required, StringLength(20)]
        public string? UserFirstName { get; set; }
        /// <summary>
        /// Il cognome dell'utente.
        /// </summary>
        [Display(Name = "Cognome"), Required, StringLength(20)]
        public string? UserLastName { get; set; }
    }
}
