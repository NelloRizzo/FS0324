using W8.Services.Dto;
using W8.Services.Dto.Utils;

namespace W8.Services.Interfaces
{
    /// <summary>
    /// Servizi per la gestione dei clienti.
    /// </summary>
    public interface ICustomerService : ICrudService<CustomerDto>
    {
        /// <summary>
        /// Restituisce una "pagina" di clienti.
        /// </summary>
        /// <param name="page">Numero della pagina.</param>
        /// <param name="pageSize">Dimensione della pagina.</param>
        Task<Page<CustomerDto>> GetPageAsync(int page, int pageSize);
    }
}
