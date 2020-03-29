using System.Data.SqlClient;

namespace Common.Contracts
{
    public interface IDataConnection
    {
        SqlConnection getConn();
    }
}
