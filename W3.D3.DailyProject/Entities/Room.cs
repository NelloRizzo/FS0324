namespace W3.D3.DailyProject.Entities
{
    /// <summary>
    /// Una sala del cinema.
    /// </summary>
    public class Room : EntityBase
    {
        /// <summary>
        /// Il nome della sala.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Il numero di posti disponibili nella sala.
        /// </summary>
        /// <remarks>Il valore <i>120</i> rappresenta il default se non viene specificata alcuna informazione
        /// per questa proprietà.</remarks>
        public int MaxAttendance { get; set; } = 120;
    }
}
