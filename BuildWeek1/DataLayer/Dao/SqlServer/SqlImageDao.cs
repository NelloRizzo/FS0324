using BuildWeek1.DataLayer.Entities;
using System.Data.SqlClient;

namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    public class SqlImageDao : SqlServerDao<ImageEntity>, IImageDao
    {
        private const string INSERT_COMMAND =
            "INSERT OUTPUT INSERTED.Id INTO Images(ProductId, Title, Description, Content, MimeType, Width, Height, Dpi) " +
            "VALUES(@productId, @title, @description, @content, @mimeType, @width, @height, @dpi)";
        private const string UPDATE_COMMAND = "UPDATE Images SET " +
            "Title = @title, Description = @description, ProductId = @productId " +
            "WHERE Id = @id";
        private const string DELETE_COMMAND = "DELETE FROM Images WHERE Id = @id";
        private const string SELECT_BY_ID_COMMAND = "SELECT Id, ProductId, Title, Description, Content, MimeType, Width, Height, Dpi " +
            "FROM CartItems WHERE Id = @id";
        public SqlImageDao(IConfiguration configuration) : base(configuration) { }

        protected override ImageEntity RowMap(SqlDataReader reader) =>
            new ImageEntity {
                Content = reader.GetSqlBinary(4).Value,
                MimeType = reader.GetString(5),
                Description = reader.GetString(3),
                Dpi = reader.GetInt32(8),
                Height = reader.GetInt32(7),
                Width = reader.GetInt32(6),
                Id = reader.GetInt32(0),
                ProductId = reader.GetInt32(2),
                Title = reader.GetString(3),
            };

        protected override SqlCommand PrepareDelete(int id) {
            var cmd = new SqlCommand(DELETE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareInsert(ImageEntity entity) {
            var cmd = new SqlCommand(INSERT_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@productId", entity.ProductId);
            cmd.Parameters.AddWithValue("@title", entity.Title);
            cmd.Parameters.AddWithValue("@description", entity.Description);
            cmd.Parameters.AddWithValue("@content", entity.Content);
            cmd.Parameters.AddWithValue("@mimeType", entity.MimeType);
            cmd.Parameters.AddWithValue("@width", entity.Width);
            cmd.Parameters.AddWithValue("@height", entity.Height);
            cmd.Parameters.AddWithValue("@dpi", entity.Dpi);
            return cmd;
        }

        protected override SqlCommand PrepareSelect(int id) {
            var cmd = new SqlCommand(SELECT_BY_ID_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareUpdate(int id, ImageEntity entity) {
            var cmd = new SqlCommand(UPDATE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@title", entity.Title);
            cmd.Parameters.AddWithValue("@description", entity.Description);
            cmd.Parameters.AddWithValue("@productId", entity.ProductId);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }
    }
}
