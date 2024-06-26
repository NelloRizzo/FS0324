using W3.D3.DailyProject.Entities;

namespace W3.D3.DailyProject.Services.V1
{
    /// <summary>
    /// Implementazione del servizio di gestione delle sale.
    /// </summary>
    public class RoomService : IRoomService
    {
        /// <summary>
        /// Il database delle sale.
        /// </summary>
        private static readonly List<Room> _rooms = [
            new Room { Name = "Sala Est", Id = 1 },
            new Room { Name = "Sala Nord", Id = 2 },
            // ho cambiato il numero di posti disponibili (invece del default 120) per testare la possibilità di completare la sala
            new Room { Name = "Sala Sud", Id = 3, MaxAttendance = 3 },
            new Room { Name = "Sala Ovest", Id = 4, MaxAttendance = 1 }
        ];

        public IEnumerable<Room> GetRooms() => _rooms;
    }
}
