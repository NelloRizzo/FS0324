namespace W8.Services.Dto.Utils
{
    /// <summary>
    /// Indica un lasso di tempo.
    /// </summary>
    public class Timelapse
    {
        /// <summary>
        /// Data iniziale.
        /// </summary>
        public required DateOnly From { get; set; }
        /// <summary>
        /// Data finale.
        /// </summary>
        public required DateOnly To { get; set; }
        /// <summary>
        /// La durata del periodo.
        /// </summary>
        public TimeSpan Timespan => To.ToDateTime(TimeOnly.MinValue) - From.ToDateTime(TimeOnly.MinValue);
    }
}
