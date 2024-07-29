namespace W8.Services.Dto
{
    /// <summary>
    /// Una città.
    /// </summary>
    public class CityDto : BaseDto
    {
        /// <summary>
        /// Denominazione.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Codice catastale.
        /// </summary>
        public required string Cadastral { get; set; }
        /// <summary>
        /// Indica se si tratta di un capoluogo di provincia.
        /// </summary>
        public bool Capital { get; set; }
        /// <summary>
        /// La provincia.
        /// </summary>
        public required ProvinceDto Province { get; set; }

        /// <inheritdoc/>
        /// <remarks>Il metodo <see cref="BaseDto.Equals(object?)"/> basa il suo 
        /// risultato proprio sul valore restituito da <strong>GetHashCode()</strong>.
        /// Nel caso di una città il confronto viene effettuato sul codice catastale.</remarks>
        public override int GetHashCode() => Cadastral.GetHashCode();
    }
}
