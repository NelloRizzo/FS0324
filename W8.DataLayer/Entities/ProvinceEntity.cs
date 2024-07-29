namespace W8.DataLayer.Entities
{
    /// <summary>
    /// Una provincia.
    /// </summary>
    public class ProvinceEntity : BaseEntity
    {
        /// <summary>
        /// Denominazione.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Sigla.
        /// </summary>
        public required string Acronym { get; set; }
    }
}
