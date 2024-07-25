using System.Data.SqlClient;
using W8.D4.WebApi.DataLayer.Entities;

namespace W8.D4.WebApi.DataLayer.Dao.SqlServer
{
    public class AuthorDao : BaseDao, IAuthorDao
    {
        private const string INSERT = "INSERT INTO Authors(Username, Password) " +
            "OUTPUT INSERTED.Id " +
            "VALUES(@username, @password)";
        private const string SELECT_FOR_LOGIN = "SELECT Id, Username, Password " +
            "FROM Authors " +
            "WHERE Username = @username AND Password = @password";
        public AuthorDao(IConfiguration config, ILogger<BaseDao> logger) : base(config, logger) { }

        public async Task<AuthorEntity> CreateAsync(AuthorEntity entity) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT, conn);
                cmd.Parameters.AddRange([
                    new SqlParameter("@username", entity.Username),
                    new SqlParameter("@password", entity.Password),
                    ]);
                entity.Id = (int)(await cmd.ExecuteScalarAsync())!;
                return entity;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Eccezione nel creare un autore");
                throw;
            }
        }

        public Task<AuthorEntity> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<AuthorEntity?> GetByUsernameAndPasswordAsync(string username, string password) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_FOR_LOGIN, conn);
                cmd.Parameters.AddRange([
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password),
                    ]);
                var reader = await cmd.ExecuteReaderAsync();
                if (reader.Read())
                    return new AuthorEntity {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                return null;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Eccezione nel login di un autore");
                throw;
            }
        }

        public Task<AuthorEntity> ReadAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<AuthorEntity> UpdateAsync(int id, AuthorEntity entity) {
            throw new NotImplementedException();
        }
    }
}
