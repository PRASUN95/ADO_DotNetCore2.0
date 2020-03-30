using Common.Contracts;
using Common.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DataConnection : IDataConnection
    {
        private readonly IConfiguration _configuration;

        public string sqlConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public DataConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetSection("ConnectionString").Value;
            var sb = new SqlConnectionStringBuilder(sqlConnectionString);
            sqlConnectionString = Convert.ToString(sb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConn()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public void LogException(AppException data)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO LogException(Exception,LogType,Module,Server) VALUES(@exception,@logType,@module,@server)", getConn()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("exception", data.ExceptionMessage));
                cmd.Parameters.Add(new SqlParameter("logType", data.LogType));
                cmd.Parameters.Add(new SqlParameter("module", data.Module));
                cmd.Parameters.Add(new SqlParameter("server", data.Machine));
                var res = cmd.ExecuteNonQuery();
            }
        }
    }
}
