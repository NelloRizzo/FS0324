using BuildWeek1.DataLayer.Entities;
using BuildWeek1.DataLayer.Exceptions;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    /// <summary>
    /// Un Dao che usa i generics per gestire tutte le entità.
    /// </summary>
    /// <typeparam name="E">Tipo di entità gestita.</typeparam>
    public abstract class SqlServerDao<E> : IDisposable, IDao<E> where E : BaseEntity
    {
        /// <summary>
        /// La connessione al database.
        /// </summary>
        protected readonly SqlConnection _connection;

        /// <summary>
        /// La connessione al database sottostante per consentire operazioni particolari e non previste.
        /// </summary>
        public DbConnection Database => _connection;

        /// <summary>
        /// Prepara il comando di INSERT.
        /// </summary>
        /// <param name="entity">Entità da inserire.</param>
        /// <returns>Il comando per l'inserimento dell'entità nel database.</returns>
        /// <remarks>Il comando di INSERT dovrà contenere la clausola OUTPUT per la fornitura
        /// del valore del campo chiave generato dal database. Tale comando sarà eseguito con
        /// il metodo ExecuteScalar anziché ExecuteNonQuery.</remarks>
        protected abstract SqlCommand PrepareInsert(E entity);
        /// <summary>
        /// Prepara il comando di UPDATE.
        /// </summary>
        /// <param name="id">Chiave dell'entità da aggiornare.</param>
        /// <param name="entity">Dati dell'entità da aggiornare.</param>
        /// <returns>Il comando per l'aggiornamento dell'entità nel database.</returns>
        protected abstract SqlCommand PrepareUpdate(int id, E entity);
        /// <summary>
        /// Prepara il comando di DELETE.
        /// </summary>
        /// <param name="id">Chiave dell'entità da eliminare.</param>
        /// <returns>Il comando per l'eliminazione dell'entità dal database.</returns>
        protected abstract SqlCommand PrepareDelete(int id);
        /// <summary>
        /// Prepara il comando di SELECT per il recupero di una entità tramite la chiave.
        /// </summary>
        /// <param name="id">Chiave dell'entità da recuperare.</param>
        /// <returns>Il comando per il recupero di un'entità tramite la chiave.</returns>
        protected abstract SqlCommand PrepareSelect(int id);
        /// <summary>
        /// Converte una riga del DataReader in una istanza dell'entità gestita.
        /// </summary>
        /// <param name="reader">Il DataReader da cui leggere.</param>
        /// <returns>L'entità ottenuta dalla lettura del record corrente nel DataReader.</returns>
        protected abstract E RowMap(SqlDataReader reader);
        /// <summary>
        /// Si assicura che la connessione sia aperta e funzionante.
        /// </summary>
        /// <exception cref="BrokenConnectionException">Nel caso in cui la connessione sia inutilizzabile.</exception>
        protected void EnsureConnectionOpened() {
            if (_connection.State == ConnectionState.Broken) throw
                    new BrokenConnectionException();
            if (_connection.State != ConnectionState.Open) _connection.Open();
        }

        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="configuration">Il gestore del file di configurazione dal quale recuperare la stringa di connessione.</param>
        public SqlServerDao(IConfiguration configuration) {
            _connection = new SqlConnection(configuration.GetConnectionString("SQLServer"));
        }

        /// <summary>
        /// Rilascia le risorse gestite.
        /// </summary>
        /// <see cref="IDisposable"/>
        public void Dispose() {
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Esegue il comando di INSERT.
        /// </summary>
        /// <param name="entity">Entità da inserire.</param>
        /// <returns>L'entità dopo l'inserimento.</returns>
        /// <exception cref="CreateException">In caso di errore durante l'esecuzione del comando sul database.</exception>
        public virtual E Create(E entity) {
            try {
                EnsureConnectionOpened();
                using var cmd = PrepareInsert(entity);
                // ATTENZIONE: Il comando è eseguito come ExecuteScalar anziché ExecuteNonQuery
                //             perché il comando di INSERT prevede la clausola OUTPUT che fornisce
                //             il valore dell'ultimo IDENTITY assegnato all'entità in fase di salvataggio
                entity.Id = (int)cmd.ExecuteScalar();
                return entity;
            }
            catch (DaoException) {
                throw;
            }
            catch (Exception ex) {
                throw new CreateException(innerException: ex);
            }
        }
        /// <summary>
        /// Esegue il comando di DELETE.
        /// </summary>
        /// <param name="id">Chiave dell'elemento da eliminare.</param>
        /// <exception cref="DeleteException">In caso di errore durante l'esecuzione del comando sul database.</exception>
        public virtual void Delete(int id) {
            try {
                EnsureConnectionOpened();
                using var cmd = PrepareDelete(id);
                var i = cmd.ExecuteNonQuery();
                if (i != 1) throw new DeleteException($"Delete command affected {i} rows");
            }
            catch (DaoException) {
                throw;
            }
            catch (Exception ex) {
                throw new DeleteException(innerException: ex);
            }
        }
        /// <summary>
        /// Recupera un'entità tramite la chiave.
        /// </summary>
        /// <param name="id">Chiave dell'entità da recuperare.</param>
        /// <returns>L'entità ottenuta dal database o <strong>null</strong> se l'entità non esiste.</returns>
        /// <exception cref="SelectException">In caso di errore durante l'esecuzione del comando sul database.</exception>
        public virtual E? Read(int id) {
            try {
                EnsureConnectionOpened();
                using var cmd = PrepareSelect(id);
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;

                return RowMap(reader);
            }
            catch (DaoException) {
                throw;
            }
            catch (Exception ex) {
                throw new SelectException(innerException: ex);
            }
        }
        /// <summary>
        /// Esegue il comando di UPDATE.
        /// </summary>
        /// <param name="id">Chiave dell'entità da aggiornare.</param>
        /// <param name="entity">Dati dell'entità da aggiornare.</param>
        /// <returns>L'entità dopo l'aggiornamento.</returns>
        /// <exception cref="UpdateException">In caso di errore durante l'esecuzione del comando sul database.</exception>
        public virtual E Update(int id, E entity) {
            try {
                EnsureConnectionOpened();
                using var cmd = PrepareUpdate(id, entity);
                var i = cmd.ExecuteNonQuery();
                if (i != 1) throw new UpdateException($"Insert command affected {i} rows");
                return Read(id) ?? throw new UpdateException($"Unable to read entity with Id = {id} after update");
            }
            catch (DaoException) {
                throw;
            }
            catch (Exception ex) {
                throw new UpdateException(innerException: ex);
            }
        }
    }
}
