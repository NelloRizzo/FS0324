namespace W3.D3.DailyProject.Entities
{
    /// <summary>
    /// Una statistica di riempimento di una sala.
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// La sala.
        /// </summary>
        public required Room Room { get; set; }
        /// <summary>
        /// Il numero di biglietti normali.
        /// </summary>
        public int NormalAttendance { get; set; }
        /// <summary>
        /// Il numero di biglietti ridotti.
        /// </summary>
        public int ReducedAttendance { get; set; }
        /// <summary>
        /// Il numero totale di biglietti venduti.
        /// </summary>
        public int Attendance => NormalAttendance + ReducedAttendance;
        /// <summary>
        /// Percentuale di riempimento della sala
        /// </summary>
        public decimal AttendancePercentage => 100m * Attendance / Room.MaxAttendance;
    }
}
