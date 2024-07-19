namespace W7.D3.DataLayer.Data.Customers
{
    /// <summary>
    /// Discriminante di tipo per l'implementazione della persistenza di classi in gerarchia ereditaria.
    /// </summary>
    public enum TypeDiscriminator
    {
        /// <summary>
        /// Discriminante per azienda.
        /// </summary>
        Company,
        /// <summary>
        /// Discriminante per privato.
        /// </summary>
        Person
    }
}
