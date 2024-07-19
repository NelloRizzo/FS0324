namespace W7.D3.DataLayer.Data.Customers
{
    /// <summary>
    /// Informazioni comuni a tutti i clienti.
    /// </summary>
    public abstract class CustomerEntity
    {
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="discriminator">Discriminante di tipo.</param>
        public CustomerEntity(TypeDiscriminator discriminator) { Discriminator = discriminator; }
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Discriminante di tipo.
        /// </summary>
        public TypeDiscriminator Discriminator { get; }
        /// <summary>
        /// Indirizzo.
        /// </summary>
        public required string Address { get; set; }
        /// <summary>
        /// Città.
        /// </summary>
        public required string City { get; set; }
        /// <summary>
        /// Regione/Provincia.
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// Codice postale.
        /// </summary>
        public required string PostalCode { get; set; }
    }
}
