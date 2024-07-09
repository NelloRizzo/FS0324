using BuildWeek1.DataLayer.Entities;
using BuildWeek1.DataLayer.Exceptions;
using System.Data.SqlClient;

namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    /// <summary>
    /// DAO per la gestione dei prodotti con Sql Server.
    /// </summary>
    public class SqlProductDao : SqlServerDao<ProductEntity>, IProductDao
    {
        private const string INSERT_COMMAND =
            "INSERT INTO Products(Title, Description, CoverId, Price) " +
            "OUTPUT INSERTED.Id " +
            "VALUES(@title, @description, @coverId, @price) ";
        private const string UPDATE_COMMAND = "UPDATE Products " +
            "SET Title = @title, Description = @description, CoverId = @coverId, Price = @price " +
            "WHERE Id = @id";
        private const string DELETE_COMMAND = "DELETE FROM Products WHERE Id = @id";
        private const string SELECT_BY_ID_COMMAND = "SELECT Id, Title, Description, CoverId, Price FROM Products WHERE Id = @id";
        private const string SELECT_ALL = "SELECT Id, Title, Description, CoverId, Price FROM Products";
        public SqlProductDao(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<ProductEntity> ReadAll() {
            var result = new List<ProductEntity>();
            try {
                EnsureConnectionOpened();
                using var cmd = new SqlCommand(SELECT_ALL, _connection);
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

        protected override ProductEntity RowMap(SqlDataReader reader) =>
            new ProductEntity {
                CoverId = reader.GetInt32(3),
                Description = reader.GetString(2),
                Price = reader.GetDecimal(4),
                Title = reader.GetString(1),
                Id = reader.GetInt32(0)
            };

        protected override SqlCommand PrepareDelete(int id) {
            var cmd = new SqlCommand(DELETE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareInsert(ProductEntity entity) {
            var cmd = new SqlCommand(INSERT_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@title", entity.Title);
            cmd.Parameters.AddWithValue("@description", entity.Description);
            cmd.Parameters.AddWithValue("@coverId", entity.CoverId);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            return cmd;
        }

        protected override SqlCommand PrepareSelect(int id) {
            var cmd = new SqlCommand(SELECT_BY_ID_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        protected override SqlCommand PrepareUpdate(int id, ProductEntity entity) {
            var cmd = new SqlCommand(UPDATE_COMMAND, _connection);
            cmd.Parameters.AddWithValue("@title", entity.Title);
            cmd.Parameters.AddWithValue("@description", entity.Description);
            cmd.Parameters.AddWithValue("@coverId", entity.CoverId);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            return cmd;
        }
    }
}
