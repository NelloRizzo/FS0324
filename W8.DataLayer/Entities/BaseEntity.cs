namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Informazioni comuni per tutte le entità.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }

        /// <inheritdoc/>
        /// <remarks>Per default l'uguaglianza tra istanze si basa su una uguaglianza
        /// tra i tipi di dato e sul valore restituito da <see cref="GetHashCode"/>.</remarks>
        public override bool Equals(object? obj) =>
            obj != null && obj.GetType() == GetType() && obj.GetHashCode() == GetHashCode();

        /// <inheritdoc/>
        /// <remarks>Il valore restituito per default dipende dalla chiave dell'entità.</remarks>
        public override int GetHashCode() => Id;
    }
}
