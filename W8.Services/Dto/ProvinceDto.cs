namespace W8.Services.Dto
{
    /// <summary>
    /// Una provincia.
    /// </summary>
    public class ProvinceDto : BaseDto
    {
        /// <summary>
        /// Denominazione.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Sigla.
        /// </summary>
        public required string Acronym { get; set; }

        /// <remarks>Il metodo <see cref="BaseDto.Equals(object?)"/> basa il suo 
        /// risultato proprio sul valore restituito da <strong>GetHashCode()</strong>.
        /// Nel caso di una provincia il confronto viene effettuato sulla sigla.</remarks>
        public override int GetHashCode() => HashCode.Combine(Acronym);
    }
}