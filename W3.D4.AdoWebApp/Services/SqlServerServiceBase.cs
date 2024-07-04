using System.Data.Common;
using System.Data.SqlClient;

namespace W3.D4.AdoWebApp.Services
{
    public class SqlServerServiceBase : ServiceBase
    {
        private SqlConnection _connection;

        public SqlServerServiceBase(IConfiguration config) {
            _connection = new SqlConnection(config.GetConnectionString("MyBlog"));
        }
        protected override DbCommand GetCommand(string commandText) {
            return new SqlCommand(commandText, _connection);
        }

        protected override DbConnection GetConnection() {
            return _connection;
        }
    }
}
