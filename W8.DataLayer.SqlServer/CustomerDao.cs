using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W8.DataLayer.Dao;
using W8.DataLayer.Dao.Exceptions;
using W8.DataLayer.Entities;
using W8.DataLayer.SqlServer.Sql;

namespace W8.DataLayer.SqlServer
{
    public class CustomerDao(
        IConfiguration configuration,
        ILogger<BaseDao<CustomerEntity>> logger)
            : BaseDao<CustomerEntity>(configuration, logger, nameof(Queries.Customers)), ICustomerDao
    {
        public override async Task<CustomerEntity> CreateAsync(CustomerEntity entity) {
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Customers.INSERT, conn);
                cmd.Parameters.AddRange(GetParameters(entity, "Id"));
                entity.Id = (int)(await cmd.ExecuteScalarAsync())!;
                return entity;
            }
            catch (SqlException ex) {
                logger.LogError(ex, "Sql exception creating customer");
                if (ex.State == 14)
                    throw new DuplicatedKeyException(innerException: ex);
                throw new DaoException(innerException: ex);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception creating customer");
                throw new DaoException(innerException: ex);
            }
        }

        /// <summary>
        /// Trasforma una riga di un DataReader in un oggetto CustomerEntity.
        /// </summary>
        /// <param name="reader">La riga da leggere.</param>
        /// <returns>L'oggetto CustomerEntity corrispondente.</returns>
        private static CustomerEntity Map(SqlDataReader reader) =>
            new() {
                Id = reader.GetInt32(0),
                LastName = reader.GetString(1),
                FirstName = reader.GetString(2),
                City = reader.GetString(3),
                Province = reader.GetString(4),
                FiscalCode = reader.GetString(5),
                Phone = reader.IsDBNull(6) ? null : reader.GetString(6),
                Mobile = reader.IsDBNull(7) ? null : reader.GetString(7),
                Email = reader.GetString(8)
            };

        public override async Task<CustomerEntity> ReadAsync(int id) {
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Customers.SELECT_BY_ID, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    return Map(reader);
                throw new Exception("Not found");
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading customer by id = {}", id);
                throw;
            }
        }

        public override async Task<CustomerEntity> UpdateAsync(int id, CustomerEntity entity) {
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Customers.UPDATE, conn);
                cmd.Parameters.AddRange(GetParameters(entity));
                cmd.Parameters.AddWithValue("@id", id);
                return await ReadAsync(id);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception updating customer");
                throw;
            }
        }

        public async Task<IEnumerable<CustomerEntity>> ReadAllAsync(int skip, int fetch) {
            var result = new List<CustomerEntity>();
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Customers.SELECT_PAGE, conn);
                cmd.Parameters.AddRange([new SqlParameter("@skip", skip), new SqlParameter("@fetch", fetch)]);
                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync()) result.Add(Map(reader));
                return result;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading customers skipping {} rows and fetching {} rows", skip, fetch);
                throw;
            }
        }
    }
}
