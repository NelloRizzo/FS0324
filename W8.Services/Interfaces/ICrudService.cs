using W8.Services.Dto;

namespace W8.Services.Interfaces
{
    /// <summary>
    /// Servizi CRUD per i DTO dell'applicazione.
    /// </summary>
    /// <typeparam name="D">Tipo di DTO gestito.</typeparam>
    public interface ICrudService<D> where D : BaseDto
    {
        /// <summary>
        /// Salva un dato.
        /// </summary>
        /// <param name="dto">Il dato da salvare.</param>
        /// <returns>Il dato dopo il salvataggio.</returns>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<D> SaveAsync(D dto);
        /// <summary>
        /// Recupera un dato tramite la chiave.
        /// </summary>
        /// <param name="id">Chiave del dato da recuperare.</param>
        /// <returns>Il dato corrispondente alla chiave.</returns>
        /// <exception cref="Exceptions.NotFoundException">Se il dato non esiste.</exception>
        Task<D> GetByIdAsync(int id);
        /// <summary>
        /// Elimina un dato tramite la chiave.
        /// </summary>
        /// <param name="id">Chiave del dato da eliminare.</param>
        /// <returns>Il dato eliminato.</returns>
        /// <exception cref="Exceptions.NotFoundException">Se il dato non esiste.</exception>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<D> DeleteByIdAsync(int id);
    }
}
