namespace W8.D4.WebApi.DataLayer.Dao
{
    /// <summary>
    /// CRUD per tutte le entità.
    /// </summary>
    /// <typeparam name="E">Tipo di entità gestita.</typeparam>
    /// <remarks>I metodi restituiscono tutti Task perché sono intesi utilizzati in 
    /// un contesto asincrono.</remarks>
    public interface IDao<E>
    {
        /// <summary>
        /// Creazione.
        /// </summary>
        /// <param name="entity">Entità da creare.</param>
        /// <returns>L'entità dopo la creazione.</returns>
        Task<E> CreateAsync(E entity);
        /// <summary>
        /// Recupero.
        /// </summary>
        /// <param name="id">Chiave dell'entità.</param>
        /// <returns>L'entità richiesta.</returns>
        Task<E> ReadAsync(int id);
        /// <summary>
        /// Modifica.
        /// </summary>
        /// <param name="id">Chiave dell'entità da modificare.</param>
        /// <param name="entity">Dati per la modifica.</param>
        /// <returns>L'entità dopo la modifica.</returns>
        Task<E> UpdateAsync(int id, E entity);
        /// <summary>
        /// Elimina un'entità.
        /// </summary>
        /// <param name="id">Chiave.</param>
        /// <returns>L'entità eliminata.</returns>
        Task<E> DeleteAsync(int id);
    }
}
