using W7.D3.BusinessLayer.Data;

namespace W7.D3.BusinessLayer
{
    /// <summary>
    /// Servizi per la gestione dei clienti.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Registra un privato.
        /// </summary>
        /// <param name="customer">Dati del cliente.</param>
        /// <returns>Restituisce il cliente dopo la registrazione.</returns>
        PersonDto RegisterPerson(PersonDto customer);
        /// <summary>
        /// Registra un'azienda.
        /// </summary>
        /// <param name="customer">Dati del cliente.</param>
        /// <returns>Restituisce il cliente dopo la registrazione.</returns>
        CompanyDto RegisterCompany(CompanyDto customer);
        /// <summary>
        /// Recupera un cliente.
        /// </summary>
        /// <param name="customerId">Chiave del cliente.</param>
        /// <returns>Il cliente corrispondente alla chiave.</returns>
        CustomerDto GetById(int customerId);
        /// <summary>
        /// Elenca tutti i clienti.
        /// </summary>
        IEnumerable<CustomerDto> GetAll();
    }
}
