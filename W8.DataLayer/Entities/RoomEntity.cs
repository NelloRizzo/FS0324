namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Tabella delle camere.
    /// </summary>
    public class RoomEntity : BaseEntity
    {
        /// <summary>
        /// Numero della camera.
        /// </summary>
        public required string Number { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Tipologia.
        /// </summary>
        public required int RoomType { get; set; }
    }
}
