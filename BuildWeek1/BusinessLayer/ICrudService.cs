using BuildWeek1.BusinessLayer.Dto;

namespace BuildWeek1.BusinessLayer
{
    /// <summary>
    /// Servizi CRUD di base.
    /// </summary>
    /// <typeparam name="D">Tipo di dato gestito.</typeparam>
    public interface ICrudService<D> : IServiceBase where D : DtoBase
    {
        /// <summary>
        /// Inserimento o modifica di un dato.
        /// </summary>
        /// <param name="dto">Dato da salvare.</param>
        /// <returns>Il dato dopo il salvataggio.</returns>
        D Save(D dto);
        /// <summary>
        /// Recupero tramite chiave.
        /// </summary>
        /// <param name="id">Chiave dell'elemento da recuperare.</param>
        /// <returns>L'elemento corrispondente alla chiave.</returns>
        D Get(int id);
        /// <summary>
        /// Eliminazione tramite chiave.
        /// </summary>
        /// <param name="id">Chiave dell'elemento da eliminare.</param>
        /// <returns>L'elemento eliminato.</returns>
        D Delete(int id);
    }
}
