using BuildWeek1.DataLayer.Entities;
using BuildWeek1.DataLayer.Exceptions;
using System.Data.SqlClient;

namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    public class SqlServerShoppingCartDao : SqlServerDao<ShoppingCartEntity>, IShoppingCartDao
    {
        private const string INSERT_COMMAND =
            "INSERT INTO ShoppingCarts(CreationDate, CustomerId, ShipFare) OUTPUT INSERTED.Id VALUES(@creationDate, @customerId, @ShipFare)";
        private const string UPDATE_COMMAND =
            "UPDATE ShoppingCarts SET ShipFare = @shipFare, Closed = @closed WHERE Id = @id";
        private const string DELETE_COMMAND = "DELETE ShoppingCarts WHERE Id = @id";
        private const string SELECT_ALL_COMMAND = "SELECT Id, CreationDate, CustomerId, ShipFare, Closed FROM ShoppingCarts WHERE Closed = 0";
        private const string SELECT_ALL_WITH_CLOSED_COMMAND = "SELECT Id, CreationDate, CustomerId, ShipFare, Closed FROM ShoppingCarts";
        private const string SELECT_BY_ID_COMMAND = "SELECT Id, CreationDate, CustomerId, ShipFare, Closed FROM ShoppingCarts WHERE Id = @id";
        private const string SELECT_BY_CUSTOMERID_COMMAND = "SELECT Id, CreationDate, CustomerId, ShipFare, Closed FROM ShoppingCarts WHERE UPPER(CustomerId) = UPPER(@customerId) AND Closed = 0";
        private const string SELECT_BY_CUSTOMERID_WITH_CLOSED_COMMAND = "SELECT Id, CreationDate, CustomerId, ShipFare, Closed FROM ShoppingCarts WHERE UPPER(CustomerId) = UPPER(@customerId)";
        private const string SELECT_COUNT_COMMAND = "SELECT COUNT(*) FROM ShoppingCarts";
        public SqlServerShoppingCartDao(IConfiguration configuration) : base(configuration) { }

        public ShoppingCartEntity? Read(int cartId, int productId) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCartEntity> ReadAll(bool retrieveClosed) {
            var result = new List<ShoppingCartEntity>();
            try {
                EnsureConnectionOpened();
                using var cmd = new SqlCommand(retrieveClosed ? SELECT_ALL_WITH_CLOSED_COMMAND : SELECT_ALL_COMMAND, _connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) result.Add(RowMap(reader));
            }
            catch (DaoException) {
                throw;
            }
            catch (Exception ex) {
                throw new SelectException(message: $"Error reading shopping carts", innerException: ex);
            }
            return result;
        }

        public IEnumerable<ShoppingCartEntity> ReadAllByCustomerId(string customerId, bool retrieveClosed) {
            var result = new List<ShoppingCartEntity>();
            try {
                EnsureConnectionOpened();
                using var cmd = new SqlCommand(retrieveClosed ? SELECT_BY_CUSTOMERID_WITH_CLOSED_COMMAND : SELECT_BY_CUSTOMERID_COMMAND, _connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) result.Add(RowMap(reader));
            }
            catch (DaoException) {
                throw;
            }
            catch (Exception ex) {
                throw new SelectException(message: $"Error reading shopping carts for customer {customerId}", innerException: ex);
            }
            return result;
        }

        protected override SqlCommand PrepareCount() {
            var cmd = new SqlCommand(SELECT_COUNT_COMMAND, _connection);
            return cmd;
        }

        protected override SqlCommand PrepareDelete(int id) {
            var cmd = new SqlCommand(DELETE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareInsert(ShoppingCartEntity entity) {
            var cmd = new SqlCommand(INSERT_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@creationDate", entity.CreationDate);
            cmd.Parameters.AddWithValue("@customerId", entity.CustomerId);
            cmd.Parameters.AddWithValue("@shipFare", entity.ShipFare);
            return cmd;
        }

        protected override SqlCommand PrepareSelect(int id) {
            var cmd = new SqlCommand(SELECT_BY_ID_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareUpdate(int id, ShoppingCartEntity entity) {
            var cmd = new SqlCommand(UPDATE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@shipFare", entity.ShipFare);
            cmd.Parameters.AddWithValue("@closed", entity.Closed);
            return cmd;
        }

        protected override ShoppingCartEntity RowMap(SqlDataReader reader) =>
            new ShoppingCartEntity {
                CustomerId = reader.GetString(2),
                Closed = reader.GetBoolean(4),
                CreationDate = reader.GetDateTime(1),
                Id = reader.GetInt32(0),
                ShipFare = reader.GetDecimal(3)
            };
    }
}
