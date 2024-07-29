using System.Data.Common;
using W8.DataLayer.Entities;

namespace W8.DataLayer.Dao
{
    /// <summary>
    /// Definizione dei metodi per la gestione di tutte le entità sul database.
    /// </summary>
    /// <typeparam name="E">Tipo di entità gestita.</typeparam>
    public interface IDao<E> where E : BaseEntity
    {
        /// <summary>
        /// Crea un'entità sul database.
        /// </summary>
        /// <param name="entity">L'entità da salvare.</param>
        /// <returns>L'entità dopo il salvataggio.</returns>
        Task<E> CreateAsync(E entity);
        /// <summary>
        /// Recupera un'entità tramite la chiave.
        /// </summary>
        /// <param name="id">La chiave dell'entità.</param>
        /// <returns>L'entità corrispondente alla chiave.</returns>
        Task<E> ReadAsync(int id);
        /// <summary>
        /// Aggiorna un'entità.
        /// </summary>
        /// <param name="id">Chiave dell'entità da aggiornare.</param>
        /// <param name="entity">I dati per l'aggiornamento.</param>
        /// <returns>L'entità dopo l'aggiornamento.</returns>
        Task<E> UpdateAsync(int id, E entity);
        /// <summary>
        /// Elimina un'entità.
        /// </summary>
        /// <param name="id">La chiave dell'entità da eliminare.</param>
        /// <returns>L'entità eliminata.</returns>
        Task<E> DeleteAsync(int id);
        /// <summary>
        /// Conta il totale dei records.
        /// </summary>
        Task<int> CountAsync();
        /// <summary>
        /// Esegue un comando custom e restituisce un DataReader per osservarne il risultato.
        /// </summary>
        /// <param name="query">Il testo SQL della query.</param>
        /// <param name="parameters">Parametri da associare alla query.</param>
        /// <returns>Il DataReader per leggere i risultati.</returns>
        Task<DbDataReader> ExecuteCustomQueryAsync(string query, Dictionary<string, object> parameters);
    }
}
