using Common.Model;
using System.Data;
using System.Data.SqlClient;

namespace Common.Contracts
{
    public interface IDataConnection
    {
        SqlConnection getConn();
        void LogException(AppException data);
    }
}
