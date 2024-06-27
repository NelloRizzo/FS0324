using W2.D4.BlogWebApp.Entities;

namespace W2.D4.BlogWebApp.Services
{
    /// <summary>
    /// Operazioni di servizio.
    /// </summary>
    /// <remarks>CRUD = Create, Read, Update, Delete.</remarks>
    /// <typeparam name="T">Tipo di dato gestito.</typeparam>
    public interface ICrudService<T> where T : BaseEntity
    {
        /// <summary>
        /// Creazione.
        /// </summary>
        /// <param name="entity">L'entità da creare.</param>
        void Create(T entity);
        /// <summary>
        /// Eliminazione.
        /// </summary>
        /// <param name="entityId">La chiave dell'entità da eliminare.</param>
        void Delete(int entityId);
        /// <summary>
        /// Ottenimento di una singola entità.
        /// </summary>
        /// <param name="entityId">La chiave dell'entità da recuperare.</param>
        /// <returns>L'entità corrispondente alla chiave.</returns>
        T GetById(int entityId);
    }
}
