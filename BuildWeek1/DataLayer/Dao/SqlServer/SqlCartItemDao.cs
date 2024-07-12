using BuildWeek1.DataLayer.Entities;
using System.Data.SqlClient;

namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    /// <summary>
    /// Dao per la gestione delle righe del carrello.
    /// </summary>
    public class SqlCartItemDao : SqlServerDao<CartItemEntity>, ICartItemDao
    {
        private const string INSERT_COMMAND =
            "INSERT INTO CartItems(CartId, ProductId, Quantity) OUTPUT INSERTED.Id VALUES(@cartId, @productId, @quantity)";
        private const string UPDATE_COMMAND = "UPDATE CartItems SET Quantity = @quantity WHERE Id = @id";
        private const string DELETE_COMMAND = "DELETE FROM CartItems WHERE Id = @id";
        private const string DELETE_BY_CART_AND_PRODUCT_COMMAND = "DELETE FROM CartItems WHERE CartId = @cartId AND ProductId = @productId";
        private const string SELECT_BY_ID_COMMAND = "SELECT Id, CartId, ProductId, Quantity FROM CartItems WHERE Id = @id";
        private const string SELECT_BY_CART_COMMAND = "SELECT Id, CartId, ProductId, Quantity FROM CartItems WHERE CartId = @cartId";
        private const string SELECT_COUNT_COMMAND = "SELECT COUNT(*) FROM CartItems";
        private const string SELECT_BY_CART_AND_PRODUCT_COMMAND = "SELECT Id, CartId, ProductId, Quantity FROM CartItems WHERE CartId = @cartId AND ProductId = @productId";
        public SqlCartItemDao(IConfiguration configuration) : base(configuration) { }

        protected override CartItemEntity RowMap(SqlDataReader reader) =>
            new CartItemEntity {
                CartId = reader.GetInt32(1),
                ProductId = reader.GetInt32(2),
                Quantity = reader.GetInt32(3),
                Id = reader.GetInt32(0),
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
            var cmd = new SqlCommand(SELECT_BY_ID_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareUpdate(int id, CartItemEntity entity) {
            var cmd = new SqlCommand(UPDATE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareCount() => new SqlCommand(SELECT_COUNT_COMMAND, _connection);

        public IEnumerable<CartItemEntity> ReadAllByCartId(int cartId) {
            throw new NotImplementedException();
        }

        public CartItemEntity Delete(int cartId, int productId) {
            var cmd = new SqlCommand(DELETE_BY_CART_AND_PRODUCT_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@cartId", cartId);
            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.ExecuteNonQuery();
            throw new NotImplementedException();
        }

        public CartItemEntity Read(int cartId, int productId) {
            throw new NotImplementedException();
        }
    }
}
