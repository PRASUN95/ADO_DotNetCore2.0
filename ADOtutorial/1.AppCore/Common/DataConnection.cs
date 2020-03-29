using Common.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Common
{
    public class DataConnection : IDataConnection
    {
        private readonly IConfiguration _configuration;

        public string sqlConnectionString { get; set; }

        public DataConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetSection("ConnectionString").Value;
        }

        public SqlConnection getConn()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
