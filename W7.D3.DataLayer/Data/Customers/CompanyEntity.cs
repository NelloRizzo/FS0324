namespace W7.D3.DataLayer.Data.Customers
{
    /// <summary>
    /// Un'azienda.
    /// </summary>
    public class CompanyEntity : CustomerEntity
    {
        public CompanyEntity() : base(TypeDiscriminator.Company) { }

        /// <summary>
        /// Denominazione.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Partita IVA.
        /// </summary>
        public required string VatCode { get; set; }

    }
}
