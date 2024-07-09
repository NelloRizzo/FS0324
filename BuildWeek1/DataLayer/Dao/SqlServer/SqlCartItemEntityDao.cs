using BuildWeek1.DataLayer.Entities;
using System.Data.SqlClient;

namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    /// <summary>
    /// Dao per la gestione delle righe del carrello.
    /// </summary>
    public class SqlCartItemEntityDao : SqlServerDao<CartItemEntity>, ICartItemEntityDao
    {
        private const string INSERT_COMMAND =
            "INSERT INTO CartItems(CartId, ProductId, Quantity) VALUES(@cartId, @productId, @quantity)";
        private const string UPDATE_COMMAND = "UPDATE CartItems SET Quantity = @quantity WHERE Id = @id";
        private const string DELETE_COMMAND = "DELETE FROM CartItems WHERE Id = @id";
        private const string SELECT_BY_CART_COMMAND = "SELECT Id, CartId, ProductId, Quantity FROM CartItems WHERE CartId = @cartId";
        public SqlCartItemEntityDao(IConfiguration configuration) : base(configuration) { }

        protected override CartItemEntity Map(SqlDataReader reader) =>
            new CartItemEntity {
                CartId = reader.GetInt32(1),
                ProductId = reader.GetInt32(2),
                Quantity = reader.GetInt32(3),
                Id = reader.GetInt32(1),
            };

        protected override SqlCommand PrepareDelete(int id) {
            var cmd = new SqlCommand(DELETE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareInsert(CartItemEntity entity) {
            var cmd = new SqlCommand(INSERT_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@cartId", entity.CartId);
            cmd.Parameters.AddWithValue("@productId", entity.ProductId);
            cmd.Parameters.AddWithValue("@quantity", entity.Quantity);
            return cmd;
        }

        protected override SqlCommand PrepareSelect(int id) {
            var cmd = new SqlCommand(SELECT_BY_CART_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareUpdate(int id, CartItemEntity entity) {
            var cmd = new SqlCommand(UPDATE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }
    }
}
