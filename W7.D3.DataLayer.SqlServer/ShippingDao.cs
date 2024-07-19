using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W7.D3.DataLayer.Dao;
using W7.D3.DataLayer.Data.Shippinggs;

namespace W7.D3.DataLayer.SqlServer
{
    public class ShippingDao : BaseDao, IShippingDao
    {
        private const string INSERT = "INSERT INTO Shippings(CustomerId, ShippingNo, ShipDate, Weight, RecipientId, Freight, DeliveryDate) " +
            "OUTPUT INSERTED.Id " +
            "VALUES(@customerId, @shippingNo, @shipDate, @weight, @recipientId, @freight, @deliveryDate)";
        private const string SELECT_BY_ID = "SELECT " +
            "Id, CustomerId, ShippingNo, ShipDate, Weight, RecipientId, Freight, DeliveryDate " +
            "FROM Shippings " +
            "WHERE Id = @id";
        private const string SELECT_ALL = "SELECT " +
            "Id, CustomerId, ShippingNo, ShipDate, Weight, RecipientId, Freight, DeliveryDate " +
            "FROM Shippings ";
        public ShippingDao(IConfiguration configuration, ILogger<UserDao> logger) : base(configuration, logger) {
        }

        public ShippingEntity Create(ShippingEntity shipping) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT, conn);
                cmd.Parameters.AddRange([
                    new SqlParameter("@customerId", shipping.Id),
                    new SqlParameter("@shippingNo", shipping.ShippingNo),
                    new SqlParameter("@shipDate", shipping.ShipDate),
                    new SqlParameter("@weight", shipping.Weight),
                    new SqlParameter("@recipientId", shipping.RecipientId),
                    new SqlParameter("@freight",shipping.Freight ),
                    new SqlParameter("@deliveryDate", shipping.DeliveryDate)
                    ]);
                shipping.Id = (int)cmd.ExecuteScalar();
                return shipping;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception creating shipping");
                throw;
            }
        }

        private static ShippingEntity Map(SqlDataReader reader) => new ShippingEntity {
            Id = reader.GetInt32(0),
            CustomerId = reader.GetInt32(1),
            ShippingNo = reader.GetString(2),
            ShipDate = DateOnly.FromDateTime(reader.GetDateTime(3)),
            Weight = reader.GetDecimal(4),
            RecipientId = reader.GetInt32(5),
            Freight = reader.GetDecimal(6),
            DeliveryDate = DateOnly.FromDateTime(reader.GetDateTime(7))
        };

        public ShippingEntity Read(int id) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_BY_ID, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read()) return Map(reader);
                throw new Exception($"Shipping with id = {id} not found");
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading shipping");
                throw;
            }
        }

        public IEnumerable<ShippingEntity> ReadAll() {
            try {
                var result = new List<ShippingEntity>();
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_ALL, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) result.Add(Map(reader));
                return result;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading shippings");
                throw;
            }
        }
    }
}
