namespace W8.Services.Dto
{
    /// <summary>
    /// Informazioni di base per tutti i DTO.
    /// </summary>
    public abstract class BaseDto
    {
        /// <summary>
        /// Chiave univoca.
        /// </summary>
        public int Id { get; set; }
        /// <inheritdoc/>
        /// <remarks>Il confronto viene effettuato prima sul tipo e poi sul risultato del metodo <see cref="GetHashCode"/>.</remarks>
        public override bool Equals(object? obj) => obj?.GetType().Equals(GetType()) ?? false && obj.GetHashCode() == GetHashCode();
        /// <inheritdoc/>
        /// <remarks>L'implementazione di default prevede che il risultato sia legato all'<see cref="Id"/>.</remarks>
        public override int GetHashCode() => Id;
    }
}
