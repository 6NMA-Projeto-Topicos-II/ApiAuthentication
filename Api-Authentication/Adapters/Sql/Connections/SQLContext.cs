using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_Authentication.Adapters.Sql.Connections
{
    public class SQLContext
    {
        private readonly ConnectionStrings _connection;
        public SQLContext(ConnectionStrings connection)
        {
            _connection = connection;
        }

        public IDbConnection ConnectLocal() => new SqlConnection(_connection.GetConnectString("ClustLocal", "DbCampusHub"));
    }
}
