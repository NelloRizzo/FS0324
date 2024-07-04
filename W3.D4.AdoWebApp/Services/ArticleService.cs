using System.Data.Common;
using System.Data.SqlClient;
using W3.D4.AdoWebApp.Models;

namespace W3.D4.AdoWebApp.Services
{
    public class ArticleService : SqlServerServiceBase, IArticleService
    {
        public ArticleService(IConfiguration config) : base(config) { }

        public void DeleteArticle(int id) {
            // prepariamo il testo del comando
            // @id è un segnaposto per un valore che fornirò quando eseguirò il comando
            var query = "DELETE FROM Articles WHERE Id = @id";
            var cmd = GetCommand(query);
            // aggiungo il valore per il parametro 
            cmd.Parameters.Add(new SqlParameter("@id", id));
            // ExecuteNonQuery esegue un comando di modifica e restituisce
            // il numero totale di righe coinvolte nell'operazione
            // DBConnection implementa l'interfaccia Closeable
            //var conn = GetConnection();
            using var conn = GetConnection();
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            // la chiamata a Close avviene automaticamente alla fine del metodo
            // conn.Close();
            if (result != 1) throw new Exception("Comando fallito");
        }

        // supponendo che all'interno della SELECT recupero i dati 
        // nella sequenza ID, TITLE, PUBLICATIONDATE, CONTENT
        private Article Create(DbDataReader reader) {
            return new Article {
                Content = reader.GetString(3),
                PublicationDate = reader.GetDateTime(2),
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
            };
        }
        public Article GetArticle(int id) {
            try {
                var cmd = GetCommand("SELECT Id, Title, PublicationDate, Content FROM Articles WHERE Id = @id");
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using var conn = GetConnection();
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return Create(reader);
                throw new Exception("Non trovato");
            }
            catch {
                throw;
            }
        }

        public IEnumerable<Article> GetArticles() {
            var cmd = GetCommand("SELECT Id, Title, PublicationDate, Content FROM Articles");
            var conn = GetConnection();
            conn.Open();
            var reader = cmd.ExecuteReader();
            var list = new List<Article>();
            while(reader.Read())
                list.Add(Create(reader));
            conn.Close();
            return list;
        }   

        public void UpdateArticle(int id, Article article) {
            throw new NotImplementedException();
        }

        public void WriteArticle(Article article) {
            var cmd = GetCommand("INSERT INTO Articles(Title, Content) VALUES(@title, @content)");
            cmd.Parameters.Add(new SqlParameter("@title", article.Title));
            cmd.Parameters.Add(new SqlParameter("@content", article.Content));
            var conn = GetConnection(); 
            conn.Open();
            var result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result != 1) throw new Exception("Inserimento fallito");
        }
    }
}
