namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Una città.
    /// </summary>
    public class CityEntity : BaseEntity
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
        /// Indica se è capoluogo di provincia.
        /// </summary>
        public bool Capital { get; set; }
        /// <summary>
        /// Chiave esterna verso le province.
        /// </summary>
        public int ProvinceId { get; set; }
    }
}
