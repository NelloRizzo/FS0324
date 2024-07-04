using System.Data.Common;

namespace W3.D4.AdoWebApp.Services
{
    public abstract class ServiceBase
    {
        private const string DDL =
            "CREATE TABLE [dbo].Articles(" +
            "   [Id] INT NOT NULL PRIMARY KEY IDENTITY," +
            "   Title NVARCHAR(80) NOT NULL," +
            "   PublicationDate DATETIME2 NULL DEFAULT GETDATE(), " +
            "   Content NVARCHAR(MAX) NOT NULL" +
            ");" +
            "CREATE TABLE [dbo].Comments(" +
            "   [Id] INT NOT NULL PRIMARY KEY IDENTITY," +
            "   Content NVARCHAR(MAX) NOT NULL," +
            "   PublicationDate DATETIME2 NULL DEFAULT GETDATE()," +
            "   ArticleId INT NOT NULL" +
            ");";
        public void CreateMetadata() {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand(DDL);
            cmd.ExecuteNonQuery();
        }
        protected abstract DbConnection GetConnection();
        protected abstract DbCommand GetCommand(string commandText);
    }
}
