using W3.D3.DailyProject.Entities;

namespace W3.D3.DailyProject.Services
{
    /// <summary>
    /// Servizi per la gestione delle sale.
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Ottiene l'elenco delle sale disponibili.
        /// </summary>
        IEnumerable<Room> GetRooms();
    }
}
