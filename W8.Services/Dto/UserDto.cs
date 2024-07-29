namespace W8.Services.Dto
{
    /// <summary>
    /// Operatore dell'applicazione.
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// Nome utente.
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Elenco di ruoli ai quali l'utente è associato.
        /// </summary>
        public List<string> Roles { get; } = []; // Inizializza la lista con una lista vuota.

        /// <inheritdoc/>
        /// <remarks>Il metodo <see cref="BaseDto.Equals(object?)"/> basa il suo risultato proprio sul 
        /// valore restituito da <strong>GetHashCode()</strong>. Nel caso di un utente
        /// il confronto viene effettuato sull'email.</remarks>
        public override int GetHashCode() => Email.GetHashCode();
    }
}
