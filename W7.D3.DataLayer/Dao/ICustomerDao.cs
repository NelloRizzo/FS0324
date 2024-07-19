using W7.D3.DataLayer.Data.Customers;

namespace W7.D3.DataLayer.Dao
{
    /// <summary>
    /// Gestione dei clienti.
    /// </summary>
    public interface ICustomerDao
    {
        /// <summary>
        /// Registra un cliente.
        /// </summary>
        /// <param name="customer">Dati del cliente.</param>
        /// <returns>Il cliente dopo la registrazione.</returns>
        CustomerEntity Create(CustomerEntity customer);
        /// <summary>
        /// Recupera un cliente tramite la chiave.
        /// </summary>
        /// <param name="customerId">Chiave del cliente da recuperare.</param>
        CustomerEntity Read(int customerId);
        /// <summary>
        /// Ottiene l'elenco di tutti i clienti.
        /// </summary>
        IEnumerable<CustomerEntity> ReadAll();
    }
}
