namespace W7.D3.DataLayer.Data.Customers
{
    /// <summary>
    /// Un cliente privato.
    /// </summary>
    public class PersonEntity : CustomerEntity
    {
        public PersonEntity() : base(TypeDiscriminator.Person) { }

        /// <summary>
        /// Nome.
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// Cognome.
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// Codice fiscale.
        /// </summary>
        public required string FiscalCode { get; set; }
    }
}
