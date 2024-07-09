using BuildWeek1.DataLayer.Entities;
using BuildWeek1.DataLayer.Exceptions;
using System.Data.SqlClient;

namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    public class SqlImageDao : SqlServerDao<ImageEntity>, IImageDao
    {
        private const string INSERT_COMMAND =
            "INSERT INTO Images(ProductId, Title, Description, Content, MimeType, Width, Height, Dpi) " +
            "OUTPUT INSERTED.Id " +
            "VALUES(@productId, @title, @description, @content, @mimeType, @width, @height, @dpi)";
        private const string UPDATE_COMMAND = "UPDATE Images SET " +
            "Title = @title, Description = @description, ProductId = @productId " +
            "WHERE Id = @id";
        private const string DELETE_COMMAND = "DELETE FROM Images WHERE Id = @id";
        private const string SELECT_BY_ID_COMMAND = "SELECT Id, ProductId, Title, Description, Content, MimeType, Width, Height, Dpi " +
            "FROM Images WHERE Id = @id";
        private const string SELECT_ALL_COMMAND = "SELECT Id, ProductId, Title, Description, Content, MimeType, Width, Height, Dpi FROM Images";
        public SqlImageDao(IConfiguration configuration) : base(configuration) { }

        protected override ImageEntity RowMap(SqlDataReader reader) =>
            new ImageEntity {
                Content = reader.GetSqlBinary(4).Value,
                MimeType = reader.GetString(5),
                Description = reader["Description"].ToString(),
                Dpi = reader["Dpi"] as int?,
                Height = reader["Height"] as int?,
                Width = reader["Width"] as int?,
                Id = reader.GetInt32(0),
                ProductId = reader["ProductId"] as int?,
                Title = reader["Title"].ToString(),
            };

        protected override SqlCommand PrepareDelete(int id) {
            var cmd = new SqlCommand(DELETE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareInsert(ImageEntity entity) {
            var cmd = new SqlCommand(INSERT_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@productId", entity.ProductId.Coalesce());
            cmd.Parameters.AddWithValue("@title", entity.Title);
            cmd.Parameters.AddWithValue("@description", entity.Description.Coalesce());
            cmd.Parameters.AddWithValue("@content", entity.Content);
            cmd.Parameters.AddWithValue("@mimeType", entity.MimeType);
            cmd.Parameters.AddWithValue("@width", entity.Width.Coalesce());
            cmd.Parameters.AddWithValue("@height", entity.Height.Coalesce());
            cmd.Parameters.AddWithValue("@dpi", entity.Dpi.Coalesce());
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
            cmd.Parameters.AddWithValue("@description", entity.Description.Coalesce());
            cmd.Parameters.AddWithValue("@productId", entity.ProductId.Coalesce());
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        public IEnumerable<ImageEntity> ReadAll() {
            var result = new List<ImageEntity>();
            try {
                EnsureConnectionOpened();
                using var cmd = new SqlCommand(SELECT_ALL_COMMAND, _connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) result.Add(RowMap(reader));
            }
            catch (DaoException) {
                throw;
            }
            catch (Exception ex) {
                throw new SelectException(innerException: ex);
            }
            return result;
        }
    }
}
