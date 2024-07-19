using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W7.D3.DataLayer.Dao;
using W7.D3.DataLayer.Data.Shippinggs;

namespace W7.D3.DataLayer.SqlServer
{
    public class ShippingUpdateDao : BaseDao, IShippingUpdateDao
    {
        private const string INSERT = "INSERT INTO ShippingsUpdates(ShippingId, UpdatedAt, Status, Description) " +
            "OUTPUT INSERTED.Id " +
            "VALUES(@shippingId, @updatedAt, @status, @description)";
        private const string SELECT_BY_SHIPPING_ID = "SELECT " +
            "Id, ShippingId, UpdatedAt, Status, Description " +
            "FROM ShippingsUpdates " +
            "WHERE ShippingId = @id";
        public ShippingUpdateDao(IConfiguration configuration, ILogger<UserDao> logger) : base(configuration, logger) {
        }

        public ShippingUpdateEntity Create(ShippingUpdateEntity shippingUpdateEntity) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT, conn);
                cmd.Parameters.AddRange([
                    new SqlParameter("@shippingId", shippingUpdateEntity.Id),
                    new SqlParameter("@updatedAt", shippingUpdateEntity.UpdatedAt),
                    new SqlParameter("@status", (int)shippingUpdateEntity.Status),
                    new SqlParameter("@description", (object?)shippingUpdateEntity.Description ?? DBNull.Value),
                    ]);
                shippingUpdateEntity.Id = (int)cmd.ExecuteScalar();
                return shippingUpdateEntity;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception creating shipping update");
                throw;
            }
        }

        public IEnumerable<ShippingUpdateEntity> GetAllByShippingId(int shippingId) {
            try {
                var result = new List<ShippingUpdateEntity>();
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_BY_SHIPPING_ID, conn);
                cmd.Parameters.AddWithValue("@id", shippingId);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) result.Add(new ShippingUpdateEntity {
                    Id = reader.GetInt32(0),
                    ShippingId = reader.GetInt32(1),
                    UpdatedAt = reader.GetDateTime(2),
                    Status = (ShippingStatus)reader.GetInt32(3),
                    Description = reader.GetString(4) ?? null
                });
                return result;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading shipping updates");
                throw;
            }
        }
    }
}
