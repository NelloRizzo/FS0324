using BuildWeek1.DataLayer.Entities;
using System.Data.Common;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione delle operazioni CRUD verso il database.
    /// </summary>
    /// <typeparam name="E">Tipo di entità gestita.</typeparam>
    public interface IDao<E> where E : BaseEntity
    {
        /// <summary>
        /// Ottiene l'accesso alla connessione con il database sottostante per esigenze particolari.
        /// </summary>
        DbConnection Database { get; }
        /// <summary>
        /// Inizia una transazione (se non ce n'è una attiva).
        /// </summary>
        DbTransaction BeginTransaction();

        /// <summary>
        /// Restituisce il numero totale di elementi presenti nel database.
        /// </summary>
        int Count();
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
