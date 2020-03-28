using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Common
{
    public class DataConnection
    {
        public string sqlConnectionString { get; set; }

        public DataConnection(string connectionString)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json");
            configurationBuilder.AddJsonFile(path,false);
            var root = configurationBuilder.Build();
            var appSetting = root.GetSection("ConnectionString");
            sqlConnectionString = appSetting.Value;
        }

        public SqlConnection getConn()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
        public void LogException()
        {

        }
    }
}
