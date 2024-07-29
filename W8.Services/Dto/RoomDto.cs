namespace W8.Services.Dto
{
    /// <summary>
    /// Tipologia di camera.
    /// </summary>
    public enum RoomType
    {
        /// <summary>
        /// Camera singola.
        /// </summary>
        Single,
        /// <summary>
        /// Camera doppia.
        /// </summary>
        Double
    }
    /// <summary>
    /// Una camera.
    /// </summary>
    public class RoomDto : BaseDto
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
        public required RoomType RoomType { get; set; }

        /// <inheritdoc/>
        /// <remarks>Il metodo <see cref="BaseDto.Equals(object?)"/> basa il suo risultato proprio sul 
        /// valore restituito da <strong>GetHashCode()</strong>. Nel caso di una camera il 
        /// confronto viene effettuato sul numero di camera.</remarks>
        public override int GetHashCode() => Number.GetHashCode();
    }
}
