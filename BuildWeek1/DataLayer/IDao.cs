using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer
{
    /// <summary>
    /// Definizione delle operazioni CRUD verso il database.
    /// </summary>
    /// <typeparam name="E">Tipo di entità gestita.</typeparam>
    public interface IDao<E> where E : BaseEntity
    {
        /// <summary>
        /// Inserimento.
        /// </summary>
        /// <param name="entity">Dati da inserire.</param>
        /// <returns>L'entità dopo l'inserimento.</returns>
        E Create(E entity);
        /// <summary>
        /// Recupero.
        /// </summary>
        /// <param name="id">Chiave dell'entità da recuperare o <strong>null</strong> se non esiste.</param>
        /// <returns></returns>
        E? Read(int id);
        /// <summary>
        /// Modifica.
        /// </summary>
        /// <param name="id">La chiave dell'entità da aggiornare.</param>
        /// <param name="entity">Dati da aggiornare.</param>
        /// <returns>L'entità dopo l'aggiornamento.</returns>
        E Update(int id, E entity);
        /// <summary>
        /// Eliminazione.
        /// </summary>
        /// <param name="id">Chiave dell'entità da eliminare.</param>
        void Delete(int id);
    }
}
