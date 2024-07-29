namespace W8.Services.Dto
{
    /// <summary>
    /// Un cliente.
    /// </summary>
    public class CustomerDto : BaseDto
    {
        /// <summary>
        /// Il cognome.
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// Il nome.
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// La città.
        /// </summary>
        public required string City { get; set; }
        /// <summary>
        /// La provincia.
        /// </summary>
        public required string Province { get; set; }
        /// <summary>
        /// Il codice fiscale.
        /// </summary>
        public required string FiscalCode { get; set; }
        /// <summary>
        /// Il numero di telefono.
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Il numero di telefono cellulare.
        /// </summary>
        public string? Mobile { get; set; }
        /// <summary>
        /// L'indirizzo email.
        /// </summary>
        public required string Email { get; set; }

        /// <inheritdoc/>
        /// <remarks>Il metodo <see cref="BaseDto.Equals(object?)"/> basa il suo 
        /// risultato proprio sul valore restituito da <strong>GetHashCode()</strong>.
        /// Nel caso di un cliente il confronto viene effettuato sul codice fiscale.</remarks>
        public override int GetHashCode() => FiscalCode.GetHashCode();
    }
}
