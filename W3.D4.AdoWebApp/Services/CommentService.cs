using System.Data.Common;
using System.Data.SqlClient;
using W3.D4.AdoWebApp.Models;

namespace W3.D4.AdoWebApp.Services
{
    public class CommentService : SqlServerServiceBase, ICommentService
    {
        public CommentService(IConfiguration config) : base(config) {
            //try {
            //    CreateMetadata();
            //}
            //catch (Exception ex) {
            //    Console.WriteLine(ex.Message);
            //}
        }

        public void DeleteComment(int commentId) {
            throw new NotImplementedException();
        }

        private Comment Create(DbDataReader reader) {
            return new Comment {
                Id = reader.GetInt32(0),
                Content = reader.GetString(1),
                PublicationDate = reader.GetDateTime(2),
                ArticleId = reader.GetInt32(3)
            };
        }
        public IEnumerable<Comment> GetAllComments(int articleId) {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand("SELECT Id, Content, PublicationDate, ArticleId FROM Comments WHERE ArticleId = @id");
            cmd.Parameters.Add(new SqlParameter("@id", articleId));
            var list = new List<Comment>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                list.Add(Create(reader));
            }
            return list;
        }

        public Comment GetComment(int commentId) {
            throw new NotImplementedException();
        }

        public void UpdateComment(int commentId, string comment) {
            throw new NotImplementedException();
        }

        public void WriteComment(int articleId, string comment) {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand("INSERT INTO Comments(Content, ArticleId) VALUES (@content, @articleId)");
            cmd.Parameters.Add(new SqlParameter("@content", comment));
            cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
            var result = cmd.ExecuteNonQuery();
            if (result != 1) throw new Exception("Inserimento fallito");
        }
    }
}
