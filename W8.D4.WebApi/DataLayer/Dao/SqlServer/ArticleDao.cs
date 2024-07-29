using System.Data.SqlClient;
using W8.D4.WebApi.DataLayer.Entities;

namespace W8.D4.WebApi.DataLayer.Dao.SqlServer
{
    public class ArticleDao : BaseDao, IArticleDao
    {
        private const string INSERT = "INSERT INTO Articles(Title, Content, AuthorId, PublicationDate)" +
            " OUTPUT INSERTED.Id" +
            " VALUES(@title, @content, @authorId, @publicationDate)";
        private const string SELECT = "SELECT Id, Title, Content, AuthorId, PublicationDate " +
            "FROM Articles " +
            "ORDER BY PublicationDate DESC";
        private const string SELECT_BY_ID = "SELECT Id, Title, Content, AuthorId, PublicationDate " +
            "FROM Articles " +
            "WHERE Id = @id";

        public ArticleDao(IConfiguration config, ILogger<BaseDao> logger) : base(config, logger) { }

        // gli step sono sempre gli stessi
        // 1. creazione della connessione
        // 2. apertura della connessione
        // 3. creazione del comando
        // 3.1. eventuale inserimento di parametri
        // 4. esecuzione del comando con lettura dei risultati
        // 5. restituzione dei risultati
        public async Task<ArticleEntity> CreateAsync(ArticleEntity entity) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT, conn);
                cmd.Parameters.AddRange([
                    new SqlParameter("@title", entity.Title),
                    new SqlParameter("@content", entity.Content),
                    new SqlParameter("@authorId", entity.AuthorId),
                    new SqlParameter("@publicationDate", entity.PublicationDate)
                    ]);
                entity.Id = (int)(await cmd.ExecuteScalarAsync())!;
                return entity;
            }
            catch (Exception ex) {
                // registro l'eccezione
                logger.LogError(ex, "Eccezione nel creare un articolo");
                // ma non la gestisco: il throw la rilancia così come l'ha ricevuta la catch
                throw;
            }
        }

        public Task<ArticleEntity> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArticleEntity>> ReadAllAsync() {
            var result = new List<ArticleEntity>();
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT, conn);
                using var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read()) {
                    result.Add(new ArticleEntity {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Content = reader.GetString(2),
                        AuthorId = reader.GetInt32(3),
                        PublicationDate = reader.GetDateTime(4),
                    });
                }
            }
            catch (Exception ex) {
                logger.LogError(ex, "Eccezione nel leggere tutti gli articoli");
                throw;
            }
            return result;
        }

        public async Task<ArticleEntity> ReadAsync(int id) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_BY_ID, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync();
                if (reader.Read()) {
                    return new ArticleEntity {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Content = reader.GetString(2),
                        AuthorId = reader.GetInt32(3),
                        PublicationDate = reader.GetDateTime(4),
                    };
                }
                throw new Exception("Non trovato");
            }
            catch (Exception ex) {
                logger.LogError(ex, "Eccezione nel leggere l'articolo con id {}", id);
                throw;
            }
        }

        public Task<ArticleEntity> UpdateAsync(int id, ArticleEntity entity) {
            throw new NotImplementedException();
        }
    }
}
