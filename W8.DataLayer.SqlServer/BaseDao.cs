using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using System.Data.SqlClient;
using W8.DataLayer.Dao;
using W8.DataLayer.Entities;
using W8.DataLayer.SqlServer.Sql;

namespace W8.DataLayer.SqlServer
{
    /// <summary>
    /// Strumenti di base utilizzabili in tutte le implementazioni dei DAO.
    /// </summary>
    /// <typeparam name="E">Tipo di entità gestita.</typeparam>
    public abstract class BaseDao<E>(IConfiguration configuration, ILogger<BaseDao<E>> logger, string tableName)
        : IDao<E> where E : BaseEntity
    {
        /// <summary>
        /// Stringa di connessione per il database.
        /// </summary>
        protected readonly string connectionString = configuration.GetConnectionString("SqlServer")!;
        /// <summary>
        /// Gestione dei messaggi di log.
        /// </summary>
        protected readonly ILogger<BaseDao<E>> logger = logger;
        /// <summary>
        /// Nome della tabella sul database.
        /// </summary>
        protected readonly string tableName = tableName;

        /// <summary>
        /// Costruisce un array di parametri a partire da una entità.
        /// </summary>
        /// <param name="entity">L'entità dalla quale prelevare i dati.</param>
        /// <param name="excluded">Eventuali proprietà dell'entità da escludere.</param>
        /// <returns>Un array di parametri con nome pari al nome della proprietà preceduto da '@'.</returns>
        /// <remarks>Se l'entità ha una proprietà <strong>Property</strong> 
        /// crea un parametro <strong>@property</strong> al quale associa il valore della proprietà.
        /// Questo metodo utilizza la cosiddetta Reflection che è una caratteristica di tutti
        /// i sistemi a virtual machine tramite la quale poter indagare via codice all'interno 
        /// delle caratteristiche strutturali degli oggetti.<br/>
        /// Per approfondire:
        /// <seealso href="https://learn.microsoft.com/en-us/dotnet/fundamentals/reflection/reflection">Reflection in .NET</seealso>
        /// </remarks>
        protected SqlParameter[] GetParameters(E entity, params string[] excluded) =>
            entity.GetType().GetProperties()
                .Where(p => !excluded.Contains(p.Name))
                .Select(p => {
                    var name = $"@{char.ToLower(p.Name[0])}{p.Name[1..]}";
                    var value = p.GetValue(entity) ?? DBNull.Value;
                    return new SqlParameter(name, value);
                }).ToArray();


        public abstract Task<E> CreateAsync(E entity);
        public async Task<E> DeleteAsync(int id) {
            try {
                var result = await ReadAsync(id);
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(string.Format(Queries.DELETE_FORMAT, tableName), conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
                return result;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception deleting from {}", tableName);
                throw;
            }
        }
        public abstract Task<E> ReadAsync(int id);
        public abstract Task<E> UpdateAsync(int id, E entity);
        public async Task<int> CountAsync() {
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(string.Format(Queries.COUNT_FORMAT, tableName), conn);
                return (int)(await cmd.ExecuteScalarAsync() ?? 0);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception counting records in {}", tableName);
                throw;
            }
        }


        /// <summary>
        /// Esegue una query custom.
        /// </summary>
        /// <param name="query">Testo della query.</param>
        /// <param name="parameters">Dizionario (string, value) che contiene i parametri associati alla query.</param>
        /// <returns>Il DataReader con il quale leggere i risultati.</returns>
        public async Task<DbDataReader> ExecuteCustomQueryAsync(string query, Dictionary<string, object> parameters) {
            try {
                var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(query, conn);
                // attraverso la tupla (k, v) legge contemporaneamente la chiave e il valore del dizionario dei parametri
                foreach (var (k, v) in parameters)
                    cmd.Parameters.Add(new SqlParameter(k, v));
                return await cmd.ExecuteReaderAsync();
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception executing custom query: {}", query);
                throw;
            }
        }
    }
}
