using W3.D3.DailyProject.Entities;

namespace W3.D3.DailyProject.Services.V1
{
    /// <summary>
    /// Implementazione del servizio di gestione degli acquisti.
    /// </summary>
    public class PurchaseService : IPurchaseService
    {
        /// <summary>
        /// Il database delle vendite.
        /// </summary>
        private static readonly List<Purchase> purchases = [];

        /// <summary>
        /// Riferimento al servizio di gestione delle sale.
        /// </summary>
        private readonly IRoomService roomService;

        /// <summary>
        /// Costruttore del servizio di gestione delle vendite.
        /// </summary>
        /// <param name="roomService">Servizio di gestione delle sale (passato tramite DI).</param>
        public PurchaseService(IRoomService roomService) {
            this.roomService = roomService;
        }
        public void AddPurchase(Purchase purchase) {
            // recupera l'Id con valore più alto tra quelli inseriti
            var lastId = purchases.Select(p => p.Id).DefaultIfEmpty(0).Max();
            // e imposta l'Id dell'elemento da aggiungere
            purchase.Id = lastId + 1;
            purchases.Add(purchase);
        }

        public IEnumerable<Purchase> GetPurchases() => purchases;

        public IEnumerable<Statistics> GetStatistics() =>
            // recupera tutte le sale
            roomService.GetRooms()
                // per ognuna di esse
                .Select(r =>
                    // crea le statistiche
                    new Statistics {
                        // la sala per la quale sta calcolando le statistiche
                        Room = r,
                        // cerca nel database delle vendite le vendite di biglietti normali per la sala e fa un conteggio
                        NormalAttendance = purchases.Where(p => p.Room.Equals(r) && p.Ticket.Type == TicketType.Normal).Count(),
                        // cerca nel database delle vendite le vendite di biglietti ridotti per la sala e fa un conteggio
                        ReducedAttendance = purchases.Where(p => p.Room.Equals(r) && p.Ticket.Type == TicketType.Reduced).Count(),
                    });
    }
}
